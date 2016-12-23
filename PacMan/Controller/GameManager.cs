using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;


namespace PacMan
{
    
    class GameManager
    {
        private string[] MapData;
        private static List<String> mapDataWithBound;
        private List<Character> ListCharacter;
        private GameMap Map;

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
                        
        
        public void DrawMap(Graphics g)
        {
            Map.Draw(g, ListCharacter);
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


        public void OnPaint(Graphics g)
        {
            Map.Draw(g, ListCharacter);
        }

        public void CharacterBehavior()
        {
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
    }
}
