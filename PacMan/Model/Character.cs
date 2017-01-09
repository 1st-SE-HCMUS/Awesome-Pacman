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
        protected GameMap.Pos MapPosition = new GameMap.Pos(2, 5); // current position in map(has bounds)
        protected PointF GraphicPosition; // current position in graphic
        protected List<Sprite> SpriteAct;

        public enum Direction { Left, Right, Up, Down }

        protected Direction CurrDirection;

        public enum CharacterState { Alive, Died, Afraid, Blinking, NeedDestroy}
        

        public CharacterState State = CharacterState.Alive;

        protected float Speed = 6f;


        /// <summary>
        /// Constructor
        /// </summary>
        public Character()
        {
            AddSprite();
            GraphicPosition = GameMap.ToGraphicPosition(MapPosition.X, MapPosition.Y);
        }

        public Character(GameMap.Pos posMap)
        {
            MapPosition = posMap;
            GraphicPosition = GameMap.ToGraphicPosition(MapPosition.X, MapPosition.Y);
        }

        
        protected int ChangeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    {
                        if (CurrDirection != Direction.Left)
                        {
                            if (GameManager.MapDataWithBound[MapPosition.Y][MapPosition.X - 1] != Constant.WallChar)
                            {
                                //MapPosition.X--;
                                AdjustPos();
                                CurrDirection = Direction.Left;

                                return 1;
                            }
                        }

                        break;
                    }
                case Direction.Right:
                    {
                        if (CurrDirection != Direction.Right)
                        {
                            if (GameManager.MapDataWithBound[MapPosition.Y][MapPosition.X + 1] != Constant.WallChar)
                            {
                                //MapPosition.X++;
                                AdjustPos();
                                CurrDirection = Direction.Right;

                                return 1;
                            }
                        }
                        break;
                    }
                case Direction.Up:
                    {
                        if (CurrDirection != Direction.Up)
                        {
                            if (GameManager.MapDataWithBound[MapPosition.Y - 1][MapPosition.X] != Constant.WallChar)
                            {
                                //MapPosition.Y--;
                                AdjustPos();
                                CurrDirection = Direction.Up;

                                return 1;
                            }
                        }
                        break;
                    }
                case Direction.Down:
                    {
                        if (CurrDirection != Direction.Down)
                        {
                            if (GameManager.MapDataWithBound[MapPosition.Y + 1][MapPosition.X] != Constant.WallChar)
                            {
                                //MapPosition.Y++;
                                AdjustPos();
                                CurrDirection = Direction.Down;

                                return 1;
                            }
                        }
                        break;
                    }
            }
            return 0;
        }


        virtual protected void Move()
        {
            if(State != CharacterState.Died)
                switch(CurrDirection)
                {
                    case Direction.Left:
                        {
                            if (GameManager.MapDataWithBound[MapPosition.Y][MapPosition.X - 1] != Constant.WallChar
                                || GameManager.GetDistance(GraphicPosition, GameMap.ToGraphicPosition(MapPosition.X - 1, MapPosition.Y)) >= GameMap.BlockSize + Speed)
                            {
                                //MapPosition.Y--;
                                GraphicPosition.X -= Speed;
                            }
                            break;
                        }
                    case Direction.Right:
                        {
                            if (GameManager.MapDataWithBound[MapPosition.Y][MapPosition.X + 1] != Constant.WallChar
                                || GameManager.GetDistance(GraphicPosition, GameMap.ToGraphicPosition(MapPosition.X + 1, MapPosition.Y)) >= GameMap.BlockSize + Speed)
                            {
                                //MapPosition.Y++;
                                GraphicPosition.X += Speed;
                            }
                            break;
                        }
                    case Direction.Up:
                        {
                            if (GameManager.MapDataWithBound[MapPosition.Y - 1][MapPosition.X] != Constant.WallChar
                                || GameManager.GetDistance(GraphicPosition, GameMap.ToGraphicPosition(MapPosition.X, MapPosition.Y - 1)) >= GameMap.BlockSize + Speed)
                            {
                                //MapPosition.X--;
                                GraphicPosition.Y -= Speed;

                            }
                            break;
                        }
                    case Direction.Down:
                        {
                            if (GameManager.MapDataWithBound[MapPosition.Y + 1][MapPosition.X] != Constant.WallChar
                                || GameManager.GetDistance(GraphicPosition, GameMap.ToGraphicPosition(MapPosition.X, MapPosition.Y + 1)) >= GameMap.BlockSize + Speed)
                            {
                                //MapPosition.X++;
                                GraphicPosition.Y += Speed;

                            }
                            break;
                        }
                }

            MapPosition = GameMap.ToMapPosition(GraphicPosition.X, GraphicPosition.Y);
        }
            
        public void UpdatePos()
        {
            Move();
        }

        private void AdjustPos()
        {
            GraphicPosition = GameMap.ToGraphicPosition(MapPosition.X, MapPosition.Y);
        }

        abstract protected int AddSprite();
        abstract public int Behave();
        virtual public int Animate(Graphics g)
        {
            PointF drawPoint = new PointF(GraphicPosition.X - Sprite.Size / 2, GraphicPosition.Y - Sprite.Size / 2);
            if(State == CharacterState.Afraid)
            {
                SpriteAct[4].draw(g, drawPoint);
                return 0;
            }
            if (State == CharacterState.Blinking)
            {
                SpriteAct[5].draw(g, drawPoint);
                return 0;
            }
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
        
        public bool DetectingCollision(Character c)
        {
            if(GameManager.GetDistance(this.GraphicPosition, c.GraphicPosition) < Sprite.Size+2)
            {
                return true;
            }

            return false;
        }

        
    }
    
}
