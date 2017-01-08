using PacMan.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PacMan
{
    
    class GameManager
    {
        public enum GameStage { Menu, Playing, Win, GameOver};
        public GameStage CurrentStage = GameStage.Menu;
        public  int PlayerScore = 0;
        public int EatedDot = 0;
        private string[] MapData;
        private static List<String> mapDataWithBound;
        public List<Character> ListCharacter;
        private GameMap Map;
        public int AfraidTime = 3000;
        public Timer TimerAfraid;
        public Timer TimerBlink;
        

        public static List<String> MapDataWithBound
        {
            get
            {
                if(mapDataWithBound != null)
                    return mapDataWithBound;
                return new List<String>();
            }
            set
            {
                mapDataWithBound = value;
            }
        }
        

        public GameManager()
        {
            mapDataWithBound = ReadFileMap();
            if (mapDataWithBound == null)
            {
                System.Windows.Forms.MessageBox.Show("Error reading map file!", "PacMan", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                //End game, or reload or something
            }
            else
                Map = new GameMap(mapDataWithBound);

            ListCharacter = new List<Character>();
            ListCharacter.Add(new CyanGhost(new Point(15, 14)));
            ListCharacter.Add(new RedGhost(new Point(18, 14)));
            ListCharacter.Add(new PinkGhost(new Point(21, 14)));
            ListCharacter.Add(new OrangeGhost(new Point(5, 17)));
            ListCharacter.Add(new Pacman());
        }
        
        public void SetCurrentStage(GameStage stage)
        {
            CurrentStage = stage;
        }

        public void addCharacter(Character c)
        {
            if (c != null)
                ListCharacter.Add(c);
        }

        public void removeCharacter(Character c)
        {
            if (c != null)
                ListCharacter.Remove(c);
        }
                         
       

        /// <summary>
        /// Read map file and create new MapData with bound
        /// </summary>
        /// <returns>
        /// null : GameMap data is wrong
        /// List<String> : Fine
        /// </returns>
        private List<String> ReadFileMap()
        {
            string resourceData = Properties.Resources.pacman_map;
            MapData = resourceData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (MapData == null || MapData.Length == 0 || MapData[0].Length == 0)
            {
                return null;
            }

            //begin create new MapData with bound
            int realMapWidth = MapData[0].Length;
            int realMapHeight = MapData.Length;
            List<String> mapDataWithBound = new List<string>();

            foreach (string element in MapData)
            {
                mapDataWithBound.Add(Constant.BoundChar + element + Constant.BoundChar);
            }

            //create string for top and bottom bound
            string TopBound = "";
            for (int i = 0; i < realMapWidth + 2; i++)
            {
                TopBound += Constant.BoundChar;
            }

            //Add top and bottom bound to mapDataWithBound
            mapDataWithBound.Insert(0, TopBound);
            mapDataWithBound.Add(TopBound);

            

                        return mapDataWithBound;
        }

        public void OnPlaying(Graphics g)
        {
            CountScore();
            if(EatedDot == 300)//eated all dot (300)
            {
                CurrentStage = GameStage.Win;
            }
            //draw map, character, item
            Draw(g, ListCharacter);
        }

        public void CharacterBehavior()
        {
            //check collision with other enemy, destroy object if nessesary
            for(int i = 0; i < ListCharacter.Count; i++)
            {
                if (ListCharacter[i].State == Character.CharacterState.NeedDestroy)
                {
                    removeCharacter(ListCharacter[i]);
                    i--;
                    break;
                }
                //enemies vs pacman
                if(i!= ListCharacter.Count-1)//not pacman vs its seft
                    if (ListCharacter[i].DetectingCollision(ListCharacter[ListCharacter.Count-1]))
                    {
                        if(ListCharacter[i].State == Character.CharacterState.Afraid 
                            || ListCharacter[i].State == Character.CharacterState.Blinking)
                        {
                            ListCharacter[i].State = Character.CharacterState.NeedDestroy;
                            //Add score...
                            i--;
                            break;
                        }
                        if(ListCharacter[i].State == Character.CharacterState.Alive)
                        {
                            ListCharacter[ListCharacter.Count - 1].State = Character.CharacterState.Died;
                        }

                    }
                
            }
            foreach (Character character in ListCharacter)
            {
                character.Behave();
            }
        }

        //for testing
        //If use this function, should move to View::GameMap.cs
        static public void DrawSolidSquare(Graphics g, Brush brush, float size, float centerX, float centerY)
        {
            float haftSize = size / 2;
            g.FillRectangle(brush, centerX - haftSize, centerY - haftSize, size, size);
        }
        
        /// <summary>
        /// Compare distance from root point to two others point
        /// </summary>
        /// <param name="p0">Root point</param>
        /// <param name="p1">Point 1</param>
        /// <param name="p2">Point 2</param>
        /// <returns>1 if dist1>dist2; -1 if <; 0 if == </returns>
        static public int CompareDistance(PointF p0, PointF p1, PointF p2)
        {
            double dist1 = GetDistance(p0, p1);
            double dist2 = GetDistance(p0, p2);

            if(dist1 >dist2)
            {
                return 1;
            }
            if(dist1 < dist2)
            {
                return -1;
            }
            return 0;
        }

        public static double GetDistance(PointF p1, PointF p2)
        {
           return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        //count and destroy item on map
        private int CountScore()
        {
            Point PacmanPos = ListCharacter[ListCharacter.Count - 1].MapPosition;
            //detect yellow dots
            if (mapDataWithBound[PacmanPos.X][PacmanPos.Y] == Constant.DotChar)
            {
                EatedDot++;
                PlayerScore += Constant.YellowDotPoint;
                StringBuilder sb = new StringBuilder(mapDataWithBound[PacmanPos.X]);
                sb[PacmanPos.Y] = ' ';

                mapDataWithBound[PacmanPos.X] = sb.ToString();
            }

            //detect fruits
            if (mapDataWithBound[PacmanPos.X][PacmanPos.Y] == Constant.FruitChar)
            {
                PlayerScore += Constant.FruitPoint;
                StringBuilder sb = new StringBuilder(mapDataWithBound[PacmanPos.X]);
                sb[PacmanPos.Y] = ' ';

                mapDataWithBound[PacmanPos.X] = sb.ToString();

                //change enemies state to afraid
                for(int i = 0; i < ListCharacter.Count-1; i++)
                {
                    ListCharacter[i].State = Character.CharacterState.Afraid;
                }

                TimerAfraid.Start();
                

            }
            return PlayerScore;
        }

        public int ShowScore(Label labelScore)
        {
            labelScore.Text = "SCORE: " +PlayerScore.ToString();
            return 0;
        }
        public void Draw(Graphics g, List<Character> characterList)
        {
            Map.DrawMap(g);

            foreach (Character character in characterList)
            {
                character.UpdatePos();
                int gameoverFlag = character.Animate(g);
                if(gameoverFlag == 1)
                {
                    CurrentStage = GameStage.GameOver;
                }
            }
        }
       
    }
}
