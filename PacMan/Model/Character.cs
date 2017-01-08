﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    abstract class Character
    {
        protected GameMap.Pos MapPosition = new GameMap.Pos(2, 5); // current position in map(has bounds)
        protected PointF GraphicPosition; // current position in graphic

        protected List<CharacterSprite> SpriteAct;

        public enum CharacterState { Alive, Died }
        public enum Direction { Left, Right, Up, Down }

        protected CharacterState State;
        protected Direction CurrDirection;
        protected float Speed = 6f;


        /// <summary>
        /// Constructor
        /// </summary>
        public Character()
        {
            AddSprite();
            GraphicPosition = GameMap.ToGraphicPosition(MapPosition.Y, MapPosition.X);
        }

        public Character(GameMap.Pos posMap)
        {
            MapPosition = posMap;
            GraphicPosition = GameMap.ToGraphicPosition(MapPosition.Y, MapPosition.X);
        }

        
        protected int ChangeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    {
                        if (CurrDirection != Direction.Left)
                        {
                            if (GameManager.MapDataWithBound[MapPosition.X - 1][MapPosition.Y] != Constant.WallChar)
                            {
                                //MapPosition.X--;
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
                            if (GameManager.MapDataWithBound[MapPosition.X + 1][MapPosition.Y] != Constant.WallChar)
                            {
                                //MapPosition.X++;
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
                            if (GameManager.MapDataWithBound[MapPosition.X][MapPosition.Y - 1] != Constant.WallChar)
                            {
                                //MapPosition.Y--;
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
                            if (GameManager.MapDataWithBound[MapPosition.X][MapPosition.Y + 1] != Constant.WallChar)
                            {
                                //MapPosition.Y++;
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
                        if (MapPosition.X - 1 >= 0 && (GameManager.MapDataWithBound[MapPosition.Y][MapPosition.X - 1] == Constant.RoadChar
                            || GameManager.GetDistance(GraphicPosition, GameMap.ToGraphicPosition(MapPosition.Y, MapPosition.X - 1)) >= GameMap.BlockSize + Speed))
                        {
                            //MapPosition.Y--;
                            GraphicPosition.X -= Speed;
                        }
                        break;
                    }
                case Direction.Right:
                    {
                        if (GameManager.MapDataWithBound[MapPosition.Y][MapPosition.X + 1] == Constant.RoadChar
                            || GameManager.GetDistance(GraphicPosition, GameMap.ToGraphicPosition(MapPosition.Y, MapPosition.X + 1)) >= GameMap.BlockSize + Speed)
                        {
                            //MapPosition.Y++;
                            GraphicPosition.X += Speed;
                        }
                        break;
                    }
                case Direction.Up:
                    {
                        if (MapPosition.Y >= 0 && (GameManager.MapDataWithBound[MapPosition.Y - 1][MapPosition.X] == Constant.RoadChar
                            || GameManager.GetDistance(GraphicPosition, GameMap.ToGraphicPosition(MapPosition.Y - 1, MapPosition.X)) >= GameMap.BlockSize + Speed))
                        {
                            //MapPosition.X--;
                            GraphicPosition.Y -= Speed;

                        }
                        break;
                    }
                case Direction.Down:
                    {
                        if (GameManager.MapDataWithBound[MapPosition.Y + 1][MapPosition.X] == Constant.RoadChar
                            || GameManager.GetDistance(GraphicPosition, GameMap.ToGraphicPosition(MapPosition.Y + 1, MapPosition.X)) >= GameMap.BlockSize + Speed)
                        {
                            //MapPosition.X++;
                            GraphicPosition.Y += Speed;

                        }
                        break;
                    }
            }

            MapPosition = GameMap.ToMapPosition(GraphicPosition.Y, GraphicPosition.X);
        }

        /// <summary>
        /// Update current position and redraw
        /// </summary>
        virtual public void UpdatePos()
        {
            Move();
            //Manager.DrawSolidSquare(g, Brushes.Yellow, CONST.MapBlockSize, GraphicPosition.X, GraphicPosition.Y);
        }

        private void AdjustPos()
        {
            GraphicPosition = GameMap.ToGraphicPosition(MapPosition.Y, MapPosition.X);
        }

        abstract protected int AddSprite();
        abstract public int Behave();
        virtual public int Animate(Graphics g)
        {
            PointF drawPoint = new PointF(GraphicPosition.X - CharacterSprite.Size / 2, GraphicPosition.Y - CharacterSprite.Size / 2);

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