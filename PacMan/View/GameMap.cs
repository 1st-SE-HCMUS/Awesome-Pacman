using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    class GameMap
    {
        public const int BlockSize = 15;
        public const float HalfBlockSize = BlockSize / 2 + 0.001f;
        public const float TopLeftX = 50;
        public const float TopLeftY = 50;

        private List<string> mapDataWithBound;


        public GameMap(List<string> mapDataWithBound)
        {
            if (mapDataWithBound != null && mapDataWithBound.Count() > 0)
                this.mapDataWithBound = mapDataWithBound;
            else
                System.Windows.Forms.MessageBox.Show("Map Data is empty!","Pacman", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }


        private void DrawMap(Graphics g)
        {
            Pen mapPen = new Pen(Color.SpringGreen, 4f);
            Brush mapBrush = Brushes.Black;

            for (int i = 1; i < mapDataWithBound.Count - 1; i++)
            {
                for (int j = 1; j < mapDataWithBound[i].Length - 1; j++)
                {
                    if (mapDataWithBound[i][j] == Constant.WallChar)
                    {
                        float posX = j * BlockSize + HalfBlockSize + TopLeftX;
                        float posY = i * BlockSize + HalfBlockSize + TopLeftY;

                        if (mapDataWithBound[i][j - 1] == Constant.WallChar)//haft line to the left
                        {
                            g.DrawLine(mapPen, posX, posY, posX - HalfBlockSize, posY);
                        }
                        if (mapDataWithBound[i][j + 1] == Constant.WallChar)//haft line to the right
                        {
                            g.DrawLine(mapPen, posX, posY, posX + HalfBlockSize, posY);
                        }
                        if (mapDataWithBound[i - 1][j] == Constant.WallChar)//haft line upward
                        {
                            g.DrawLine(mapPen, posX, posY, posX, posY - HalfBlockSize);
                        }
                        if (mapDataWithBound[i + 1][j] == Constant.WallChar)//haft line downward
                        {
                            g.DrawLine(mapPen, posX, posY, posX, posY + HalfBlockSize);
                        }


                    }
                }
            }
        }


        public void Draw(Graphics g, List<Character> characterList)
        {
            DrawMap(g);
            foreach (Character character in characterList)
            {
                character.UpdatePos();
                character.Animate(g);

            }
        }


        /// <summary>
        /// convert position in map(has bounds) to position in graphic
        /// </summary>
        /// <returns></returns>
        public static PointF ToGraphicPosition(int row, int col)
        {
            PointF posGraph = new PointF();
            posGraph.X = col * BlockSize + HalfBlockSize + TopLeftX;
            posGraph.Y = row * BlockSize + HalfBlockSize + TopLeftY;

            return posGraph;
        }

        public static Point ToMapPosition(float posX, float posY)
        {
            //Point closestPosMap = MapPosition;
            //double minDistance = Manager.GetDistance(MapPosition, new PointF(posX, posY));
            int j = (int)Math.Round((posX - HalfBlockSize - TopLeftX) / BlockSize);
            int i = (int)Math.Round((posY - HalfBlockSize - TopLeftY) / BlockSize);

            return new Point(i, j);
        }
     

    }
}
