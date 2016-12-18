using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int readFileMap()
        {
            return readFileMap(ref MapDataWithBound);
        }
        public void drawMap(Graphics g)
        {
            drawMap(g, MapDataWithBound);
        }

        //private
        private int readFileMap(ref List<string> mapDataWithBound)
        {
            MapData = System.IO.File.ReadAllLines(CONST.PATH_FILE_MAP);


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
                mapDataWithBound.Add(CONST.BOUND_CHAR + element + CONST.BOUND_CHAR);
            }

            //create string for top and bottom bound
            string TopBound = "";
            for (int i = 0; i < realMapWidth + 2; i++)
            {
                TopBound += CONST.BOUND_CHAR;
            }
            //Add top and bottom bound to mapDataWithBound
            mapDataWithBound.Insert(0, TopBound);
            mapDataWithBound.Add(TopBound);
            return 0;
        }
        private void drawMap(Graphics g, List<string> mapDataWithBound)
        {
            Pen mapPen = new Pen(Color.SpringGreen, 4f);
            Brush mapBrush = Brushes.Black;

            for (int i = 1; i < mapDataWithBound.Count - 1; i++)
            {
                for (int j = 1; j < mapDataWithBound[i].Length - 1; j++)
                {
                    if (mapDataWithBound[i][j] == CONST.WALL_CHAR)
                    {
                        float posX = j * CONST.SIZE_MAP_BLOCK + CONST.HAFT_SIZE_MAP_BLOCK + CONST.MAP_TOP_LEFT_X;
                        float posY = i * CONST.SIZE_MAP_BLOCK + CONST.HAFT_SIZE_MAP_BLOCK + CONST.MAP_TOP_LEFT_Y;

                        if (mapDataWithBound[i][j - 1] == CONST.WALL_CHAR)//haft line to the left
                        {
                            g.DrawLine(mapPen, posX, posY, posX - CONST.HAFT_SIZE_MAP_BLOCK, posY);
                        }
                        if (mapDataWithBound[i][j + 1] == CONST.WALL_CHAR)//haft line to the right
                        {
                            g.DrawLine(mapPen, posX, posY, posX + CONST.HAFT_SIZE_MAP_BLOCK, posY);
                        }
                        if (mapDataWithBound[i - 1][j] == CONST.WALL_CHAR)//haft line upward
                        {
                            g.DrawLine(mapPen, posX, posY, posX, posY - CONST.HAFT_SIZE_MAP_BLOCK);
                        }
                        if (mapDataWithBound[i + 1][j] == CONST.WALL_CHAR)//haft line downward
                        {
                            g.DrawLine(mapPen, posX, posY, posX, posY + CONST.HAFT_SIZE_MAP_BLOCK);
                        }


                    }
                }
            }
        }


        public void runInPaint(Graphics g, List<Character> character)
        {
            drawMap(g);
            foreach(Character _character in character)
            {
                _character.updatePos(g);
                _character.animate(g);

            }
        }

        public void characterBehavior(List<Character> character)
        {
            foreach (Character _character in character)
            {
                _character.behave();
            }
        }
        //for testing
        static public void drawSolidSquare(Graphics g, Brush brush, float size, float centerX, float centerY)
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
        static public int compareDistance(PointF p0, PointF p1, PointF p2)
        {
            double dist1 = getDistance(p0, p1);
            double dist2 = getDistance(p0, p2);

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

        static public double getDistance(PointF p1, PointF p2)
        {
           return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
