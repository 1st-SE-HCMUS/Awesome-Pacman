using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices;

namespace PacMan
{
    class PacmanControl
    {
        Point PosMap = new Point(5, 2); // current position in map(has bounds)
        PointF PosGraph; // current position in graphic
        bool needAdjustPos = false;
        enum STATE { Alive, Died }
        enum DIRECTION { Left, Right, Up, Down }

        STATE State;
        DIRECTION CurrDirection = DIRECTION.Right;
        float Speed = 6f;

        public PacmanControl()
        {
            PosGraph = PosMapToGraphic(PosMap.X, PosMap.Y);
        }

        /// <summary>
        /// convert position in map(has bounds) to position in graphic
        /// </summary>
        /// <returns></returns>
        PointF PosMapToGraphic(int i, int j)
        {
            PointF posGraph = new PointF();
            posGraph.X = j * CONST.SIZE_MAP_BLOCK + CONST.HAFT_SIZE_MAP_BLOCK + CONST.MAP_TOP_LEFT_X;
            posGraph.Y = i * CONST.SIZE_MAP_BLOCK + CONST.HAFT_SIZE_MAP_BLOCK + CONST.MAP_TOP_LEFT_Y;

            return posGraph;
        }
        Point PosGraphicToMap(float posX, float posY)
        {
            //Point closestPosMap = PosMap;
            //double minDistance = Manager.getDistance(PosMap, new PointF(posX, posY));
            int j = (int)Math.Round((posX - CONST.HAFT_SIZE_MAP_BLOCK - CONST.MAP_TOP_LEFT_X) / CONST.SIZE_MAP_BLOCK);
            int i = (int)Math.Round((posY - CONST.HAFT_SIZE_MAP_BLOCK - CONST.MAP_TOP_LEFT_Y) / CONST.SIZE_MAP_BLOCK);

            return new Point(i, j);
        }

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(UInt16 virtualKeyCode);
        private const UInt16 VK_LEFT = 0x25;
        private const UInt16 VK_RIGHT = 0x27;
        private const UInt16 VK_UP = 0x26;
        private const UInt16 VK_DOWN = 0x28;
        public int ChangeDirection()
        {
            if((GetAsyncKeyState( VK_LEFT ) & 0x8000) != 0)
            {
                if (CurrDirection != DIRECTION.Left)
                {
                    if (Manager.MapDataWithBound[PosMap.X][PosMap.Y - 1] != CONST.WALL_CHAR)
                    {
                        needAdjustPos = true;
                        CurrDirection = DIRECTION.Left;
                    }
                }
                return 0;
            }

                if((GetAsyncKeyState( VK_RIGHT ) & 0x8000) != 0)
            {

                        if (CurrDirection != DIRECTION.Right)
                        {
                            if (Manager.MapDataWithBound[PosMap.X][PosMap.Y + 1] != CONST.WALL_CHAR)
                            {
                                needAdjustPos = true;
                                CurrDirection = DIRECTION.Right;
                            }
                        }

                        return 0;
                    }
            if((GetAsyncKeyState( VK_UP ) & 0x8000) != 0)
            {
                        if (CurrDirection != DIRECTION.Up)
                        {
                            if (Manager.MapDataWithBound[PosMap.X - 1][PosMap.Y] != CONST.WALL_CHAR)
                            {
                                needAdjustPos = true;
                                CurrDirection = DIRECTION.Up;
                            }
                        }
                        return 0;
                    }
            if ((GetAsyncKeyState(VK_DOWN) & 0x8000) != 0)
            {
                    {
                        if (CurrDirection != DIRECTION.Down)
                        {
                            if (Manager.MapDataWithBound[PosMap.X + 1][PosMap.Y] != CONST.WALL_CHAR)
                            {
                                needAdjustPos = true;
                                CurrDirection = DIRECTION.Down;
                            }
                        }
                        return 0;
                    }
            }
            return 0;
        }
                
        private void Move()
        {
            switch(CurrDirection)
            {
                case DIRECTION.Left:
                    {
                        if (Manager.MapDataWithBound[PosMap.X][PosMap.Y - 1] == CONST.ROAD_CHAR
                            || Manager.getDistance(PosGraph, PosMapToGraphic(PosMap.X, PosMap.Y - 1)) >= CONST.SIZE_MAP_BLOCK + Speed)
                        {
                            //PosMap.Y--;
                            PosGraph.X -= Speed;
                        }
                        break;
                    }
                case DIRECTION.Right:
                    {
                        if (Manager.MapDataWithBound[PosMap.X][PosMap.Y + 1] == CONST.ROAD_CHAR
                            || Manager.getDistance(PosGraph, PosMapToGraphic(PosMap.X, PosMap.Y + 1)) >= CONST.SIZE_MAP_BLOCK + Speed)
                        {
                            //PosMap.Y++;
                            PosGraph.X += Speed;
                        }
                        break;
                    }
                case DIRECTION.Up:
                    {
                        if (Manager.MapDataWithBound[PosMap.X - 1][PosMap.Y] == CONST.ROAD_CHAR
                            || Manager.getDistance(PosGraph, PosMapToGraphic(PosMap.X - 1, PosMap.Y)) >= CONST.SIZE_MAP_BLOCK + Speed)
                        {
                            //PosMap.X--;
                            PosGraph.Y -= Speed;

                        }
                        break;
                    }
                case DIRECTION.Down:
                    {
                        if (Manager.MapDataWithBound[PosMap.X + 1][PosMap.Y] == CONST.ROAD_CHAR
                            || Manager.getDistance(PosGraph, PosMapToGraphic(PosMap.X + 1, PosMap.Y)) >= CONST.SIZE_MAP_BLOCK + Speed)
                        {
                            //PosMap.X++;
                            PosGraph.Y += Speed;

                        }
                        break;
                    }
            }

            PosMap = PosGraphicToMap(PosGraph.X, PosGraph.Y);
        }

        /// <summary>
        /// Update current position and redraw
        /// </summary>
        public void UpdatePos(Graphics g)
        {
            //PointF pos = PosMapToGraphic(PosMap.X, PosMap.Y);
            g.DrawLine(Pens.Red, PosGraph, PosMapToGraphic(PosMap.X + 1, PosMap.Y));
            g.DrawLine(Pens.Red, PosGraph, PosMapToGraphic(PosMap.X - 1, PosMap.Y));
            g.DrawLine(Pens.Red, PosGraph, PosMapToGraphic(PosMap.X, PosMap.Y + 1));
            g.DrawLine(Pens.Red, PosGraph, PosMapToGraphic(PosMap.X, PosMap.Y - 1));

            if (needAdjustPos == true)
            {
                PosGraph = PosMapToGraphic(PosMap.X, PosMap.Y);
                needAdjustPos = false;
            }
            Move();
            Manager.drawSolidSquare(g, Brushes.Yellow, CONST.SIZE_MAP_BLOCK, PosGraph.X, PosGraph.Y);
        }
    }
}
