using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;


namespace PacMan
{
    
    class Manager
    {
        static public string[] MapData;
        static public List<String> MapDataWithBound;
                        
        /// <summary>
        /// Read map file and create new MapData with bound
        /// </summary>
        /// <returns>
        /// 1 : Map data is wrong
        /// 0 : Fine
        /// </returns>
        public int ReadFileMap()
        {
            return ReadFileMap(ref MapDataWithBound);
        }

        public void DrawMap(Graphics g)
        {
            DrawMap(g, MapDataWithBound);
        }

        //private
        private int ReadFileMap(ref List<string> mapDataWithBound)
        {
            string resource_data = Properties.Resources.pacman_map;
            MapData = resource_data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToArray();


            if (MapData.Length == 0)
            {
                return 1;
            }
            else
            {
                if (MapData[0].Length == 0)
                {
                    return 1;
                }
            }

            //begin create new MapData with bound
            int realMapWidth = MapData[0].Length;
            int realMapHeight = MapData.Length;
            mapDataWithBound = new List<string>();

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
            return 0;
        }
        private void DrawMap(Graphics g, List<string> mapDataWithBound)
        {
            Pen mapPen = new Pen(Color.SpringGreen, 4f);
            Brush mapBrush = Brushes.Black;

            for (int i = 1; i < mapDataWithBound.Count - 1; i++)
            {
                for (int j = 1; j < mapDataWithBound[i].Length - 1; j++)
                {
                    if (mapDataWithBound[i][j] == Constant.WallChar)
                    {
                        float posX = j * Constant.MapBlockSize + Constant.HalfMapBlockSize + Constant.MapTopLeftX;
                        float posY = i * Constant.MapBlockSize + Constant.HalfMapBlockSize + Constant.MapTopLeftY;

                        if (mapDataWithBound[i][j - 1] == Constant.WallChar)//haft line to the left
                        {
                            g.DrawLine(mapPen, posX, posY, posX - Constant.HalfMapBlockSize, posY);
                        }
                        if (mapDataWithBound[i][j + 1] == Constant.WallChar)//haft line to the right
                        {
                            g.DrawLine(mapPen, posX, posY, posX + Constant.HalfMapBlockSize, posY);
                        }
                        if (mapDataWithBound[i - 1][j] == Constant.WallChar)//haft line upward
                        {
                            g.DrawLine(mapPen, posX, posY, posX, posY - Constant.HalfMapBlockSize);
                        }
                        if (mapDataWithBound[i + 1][j] == Constant.WallChar)//haft line downward
                        {
                            g.DrawLine(mapPen, posX, posY, posX, posY + Constant.HalfMapBlockSize);
                        }


                    }
                }
            }
        }


        public void RunInPaint(Graphics g, List<Character> characterList)
        {
            DrawMap(g);
            foreach(Character character in characterList)
            {
                character.UpdatePos(g);
                character.Animate(g);

            }
        }

        public void CharacterBehavior(List<Character> characterList)
        {
            foreach (Character character in characterList)
            {
                character.Behave();
            }
        }
        //for testing
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

        static public double GetDistance(PointF p1, PointF p2)
        {
           return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
