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

        protected List<SpriteControl> SpriteAct;

        protected enum CharacterState { Alive, Died }
        protected enum Direction { Left, Right, Up, Down }

        protected CharacterState State;
        protected Direction CurrDirection = Direction.Right;
        protected float Speed = 6f;

        /// <summary>
        /// Constructor
        /// </summary>
        public Character()
        {
            AddSprite();
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
            posGraph.X = j * Constant.MapBlockSize + Constant.HalfMapBlockSize + Constant.MapTopLeftX;
            posGraph.Y = i * Constant.MapBlockSize + Constant.HalfMapBlockSize + Constant.MapTopLeftY;

            return posGraph;
        }
        protected Point PosGraphicToMap(float posX, float posY)
        {
            //Point closestPosMap = PosMap;
            //double minDistance = Manager.GetDistance(PosMap, new PointF(posX, posY));
            int j = (int)Math.Round((posX - Constant.HalfMapBlockSize - Constant.MapTopLeftX) / Constant.MapBlockSize);
            int i = (int)Math.Round((posY - Constant.HalfMapBlockSize - Constant.MapTopLeftY) / Constant.MapBlockSize);

            return new Point(i, j);
        }     
        
        protected int ChangeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    {
                        if (CurrDirection != Direction.Left)
                        {
                            if (Manager.MapDataWithBound[PosMap.X][PosMap.Y - 1] != Constant.WallChar)
                            {
                                AdjustPos();
                                CurrDirection = Direction.Left;
                            }
                        }

                        break;
                    }
                case Direction.Right:
                    {
                        if (CurrDirection != Direction.Right)
                        {
                            if (Manager.MapDataWithBound[PosMap.X][PosMap.Y + 1] != Constant.WallChar)
                            {
                                AdjustPos();
                                CurrDirection = Direction.Right;
                            }
                        }
                        break;
                    }
                case Direction.Up:
                    {
                        if (CurrDirection != Direction.Up)
                        {
                            if (Manager.MapDataWithBound[PosMap.X - 1][PosMap.Y] != Constant.WallChar)
                            {
                                AdjustPos();
                                CurrDirection = Direction.Up;
                            }
                        }
                        break;
                    }
                case Direction.Down:
                    {
                        if (CurrDirection != Direction.Down)
                        {
                            if (Manager.MapDataWithBound[PosMap.X + 1][PosMap.Y] != Constant.WallChar)
                            {
                                AdjustPos();
                                CurrDirection = Direction.Down;
                            }
                        }
                        break;
                    }
            }
            return 0;
        }


        virtual protected void Move()
        {
            switch(CurrDirection)
            {
                case Direction.Left:
                    {
                        if (Manager.MapDataWithBound[PosMap.X][PosMap.Y - 1] == Constant.RoadChar
                            || Manager.GetDistance(PosGraph, PosMapToGraphic(PosMap.X, PosMap.Y - 1)) >= Constant.MapBlockSize + Speed)
                        {
                            //PosMap.Y--;
                            PosGraph.X -= Speed;
                        }
                        break;
                    }
                case Direction.Right:
                    {
                        if (Manager.MapDataWithBound[PosMap.X][PosMap.Y + 1] == Constant.RoadChar
                            || Manager.GetDistance(PosGraph, PosMapToGraphic(PosMap.X, PosMap.Y + 1)) >= Constant.MapBlockSize + Speed)
                        {
                            //PosMap.Y++;
                            PosGraph.X += Speed;
                        }
                        break;
                    }
                case Direction.Up:
                    {
                        if (Manager.MapDataWithBound[PosMap.X - 1][PosMap.Y] == Constant.RoadChar
                            || Manager.GetDistance(PosGraph, PosMapToGraphic(PosMap.X - 1, PosMap.Y)) >= Constant.MapBlockSize + Speed)
                        {
                            //PosMap.X--;
                            PosGraph.Y -= Speed;

                        }
                        break;
                    }
                case Direction.Down:
                    {
                        if (Manager.MapDataWithBound[PosMap.X + 1][PosMap.Y] == Constant.RoadChar
                            || Manager.GetDistance(PosGraph, PosMapToGraphic(PosMap.X + 1, PosMap.Y)) >= Constant.MapBlockSize + Speed)
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
            //g.DrawLine(Pens.Red, PosGraph, PosMapToGraphic(PosMap.X + 1, PosMap.Y));
            //g.DrawLine(Pens.Red, PosGraph, PosMapToGraphic(PosMap.X - 1, PosMap.Y));
            //g.DrawLine(Pens.Red, PosGraph, PosMapToGraphic(PosMap.X, PosMap.Y + 1));
            //g.DrawLine(Pens.Red, PosGraph, PosMapToGraphic(PosMap.X, PosMap.Y - 1));

            
            Move();
            //Manager.DrawSolidSquare(g, Brushes.Yellow, CONST.MapBlockSize, PosGraph.X, PosGraph.Y);
        }

        private void AdjustPos()
        {
            PosGraph = PosMapToGraphic(PosMap.X, PosMap.Y);
        }

        abstract protected int AddSprite();
        abstract public int Behave();
        virtual public int Animate(Graphics g)
        {
            PointF drawPoint = new PointF(PosGraph.X - Constant.SpriteSize / 2, PosGraph.Y - Constant.SpriteSize / 2);

            switch (CurrDirection)
            {
                case Direction.Left:
                    {
                        SpriteAct[0].draw(g, drawPoint);
                        break;
                    }
                case Direction.Right:
                    {
                        SpriteAct[1].draw(g, drawPoint);
                        break;
                    }
                case Direction.Up:
                    {
                        SpriteAct[2].draw(g, drawPoint);
                        break;
                    }
                case Direction.Down:
                    {
                        SpriteAct[3].draw(g, drawPoint);
                        break;
                    }
            }
            return 0;
        }
        
    }
    
}
