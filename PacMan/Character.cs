using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    abstract class Character
    {
        protected Point PosMap = new Point(5, 2); // current position in map(has bounds)
        protected PointF PosGraph; // current position in graphic
        protected bool needAdjustPos = false;
        protected enum STATE { Alive, Died }
        protected enum DIRECTION { Left, Right, Up, Down }

        protected STATE State;
        protected DIRECTION CurrDirection = DIRECTION.Right;
        protected float Speed = 6f;

        /// <summary>
        /// Constructor
        /// </summary>
        public Character()
        {
            PosGraph = PosMapToGraphic(PosMap.X, PosMap.Y);
        }
        public Character(Point posMap)
        {
            PosMap = posMap;
            PosGraph = PosMapToGraphic(PosMap.X, PosMap.Y);
        }

        /// <summary>
        /// convert position in map(has bounds) to position in graphic
        /// </summary>
        /// <returns></returns>
        protected PointF PosMapToGraphic(int i, int j)
        {
            PointF posGraph = new PointF();
            posGraph.X = j * CONST.SIZE_MAP_BLOCK + CONST.HAFT_SIZE_MAP_BLOCK + CONST.MAP_TOP_LEFT_X;
            posGraph.Y = i * CONST.SIZE_MAP_BLOCK + CONST.HAFT_SIZE_MAP_BLOCK + CONST.MAP_TOP_LEFT_Y;

            return posGraph;
        }
        protected Point PosGraphicToMap(float posX, float posY)
        {
            //Point closestPosMap = PosMap;
            //double minDistance = Manager.getDistance(PosMap, new PointF(posX, posY));
            int j = (int)Math.Round((posX - CONST.HAFT_SIZE_MAP_BLOCK - CONST.MAP_TOP_LEFT_X) / CONST.SIZE_MAP_BLOCK);
            int i = (int)Math.Round((posY - CONST.HAFT_SIZE_MAP_BLOCK - CONST.MAP_TOP_LEFT_Y) / CONST.SIZE_MAP_BLOCK);

            return new Point(i, j);
        }

        abstract public int ChangeDirection();
                
        virtual protected void Move()
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
        virtual public void UpdatePos(Graphics g)
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
