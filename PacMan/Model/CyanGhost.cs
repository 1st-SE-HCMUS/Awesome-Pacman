using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    class CyanGhost : Enemy
    {
        public CyanGhost(GameMap.Pos startPoint)
        {
            MapPosition = startPoint;
            turnPoint = new GameMap.Pos(27, 33);
            GraphicPosition = GameMap.ToGraphicPosition(MapPosition.X, MapPosition.Y);
        }
        protected override int AddSprite()
        {
            SpriteAct = new List<Sprite>();
            List<Bitmap> up = new List<Bitmap>();
            List<Bitmap> down = new List<Bitmap>();
            List<Bitmap> left = new List<Bitmap>();
            List<Bitmap> right = new List<Bitmap>();
            List<Bitmap> afraid = new List<Bitmap>();
            List<Bitmap> blink = new List<Bitmap>();

            afraid.Add(new Bitmap(Properties.Resources.afraid__1_, Sprite.Size, Sprite.Size));
            afraid.Add(new Bitmap(Properties.Resources.afraid__2_, Sprite.Size, Sprite.Size));

            blink.Add(new Bitmap(Properties.Resources.afraid_blink__1_, Sprite.Size, Sprite.Size));
            blink.Add(new Bitmap(Properties.Resources.afraid_blink__1_1, Sprite.Size, Sprite.Size));

            up.Add(new Bitmap(Properties.Resources.blue__1_, Sprite.Size, Sprite.Size));
            up.Add(new Bitmap(Properties.Resources.blue__2_, Sprite.Size, Sprite.Size));

            down.Add(new Bitmap(Properties.Resources.blue__3_, Sprite.Size, Sprite.Size));
            down.Add(new Bitmap(Properties.Resources.blue__4_, Sprite.Size, Sprite.Size));

            left.Add(new Bitmap(Properties.Resources.blue__5_, Sprite.Size, Sprite.Size));
            left.Add(new Bitmap(Properties.Resources.blue__6_, Sprite.Size, Sprite.Size));

            right.Add(new Bitmap(Properties.Resources.blue__7_, Sprite.Size, Sprite.Size));
            right.Add(new Bitmap(Properties.Resources.blue__8_, Sprite.Size, Sprite.Size));


            SpriteAct.Add(new Sprite(left));
            SpriteAct.Add(new Sprite(right));
            SpriteAct.Add(new Sprite(up));
            SpriteAct.Add(new Sprite(down));
            SpriteAct.Add(new Sprite(afraid));
            SpriteAct.Add(new Sprite(blink));


            return 0;
        }

        public override int Behave()
        {
            GameManager manager = GameManager.GetInstance();
            if (Mode == EnemyMode.Chase)
            {
                //
                return ChooseWayToGo(manager.GetMap(), manager.GetPacmanPosition());
            }
            else if (Mode == EnemyMode.Scatter)
            {
                //Scatter
                //Scatter
                if (MapPosition.X == turnPoint.X && MapPosition.Y == turnPoint.Y && reachedCorner != true)
                {
                    reachedCorner = true;
                    CurrDirection = Direction.Left;
                }
                if (reachedCorner == true)
                {
                    if (MapPosition.X != turnPoint.X || MapPosition.Y != turnPoint.Y)
                    {
                        bool canTurnRight = CheckAvailableWay(GetRightDirection(CurrDirection));
                        if (canTurnRight)
                        {
                            if (ChangeDirection(GetRightDirection(CurrDirection)) == 1)
                            {
                                turnPoint = MapPosition;
                                return 1;
                            }
                        }

                        if(!canTurnRight && !CheckAvailableWay(CurrDirection))
                        {
                            if (ChangeDirection(GetLeftDirection(CurrDirection)) == 1)
                            {
                                turnPoint = MapPosition;
                                return 1;
                            }
                        }      
                    }

                    return 1;
                }

                return ChooseWayToGo(manager.GetMap(), new GameMap.Pos(27, 33));
            }
            // Fuck..., no way to pacman
            else
            {
                //Pissed mode
                return 0;
            }
        }
    }
}
