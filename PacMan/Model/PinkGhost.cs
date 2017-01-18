using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    class PinkGhost : Enemy
    {
        public PinkGhost(GameMap.Pos startPoint)
        {
            Score += -200;
            Speed += -0.5f;
            id = 2;
            MapPosition = startPoint;
            scatterTargetPoint = new GameMap.Pos(2, 5);
            turnPoint = scatterTargetPoint;
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

            up.Add(new Bitmap(Properties.Resources.pink__1_, Sprite.Size, Sprite.Size));
            up.Add(new Bitmap(Properties.Resources.pink__2_, Sprite.Size, Sprite.Size));

            down.Add(new Bitmap(Properties.Resources.pink__3_, Sprite.Size, Sprite.Size));
            down.Add(new Bitmap(Properties.Resources.pink__5_, Sprite.Size, Sprite.Size));

            left.Add(new Bitmap(Properties.Resources.pink__6_, Sprite.Size, Sprite.Size));
            left.Add(new Bitmap(Properties.Resources.pink__8_, Sprite.Size, Sprite.Size));

            right.Add(new Bitmap(Properties.Resources.pink__7_, Sprite.Size, Sprite.Size));
            right.Add(new Bitmap(Properties.Resources.pink__4_, Sprite.Size, Sprite.Size));


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
                return GoScatter(Direction.Down);
            }
            // Fuck..., no way to pacman
            else
            {
                //Pissed mode
                return 0;
            }
        }

        public override int GoScatter(Direction startDirection)
        {
            int baseResult = base.GoScatter(startDirection);
            if (baseResult == 1)
            {
                bool canTurnRight = CheckAvailableWay(GetTurnDirection(CurrDirection, Direction.Left));
                if (canTurnRight)
                {
                    if (ChangeDirection(GetTurnDirection(CurrDirection, Direction.Left)) == 1)
                    {
                        turnPoint = MapPosition;
                        return 1;
                    }
                }
            }
            else if (baseResult == -1)
            {
                return ChooseWayToGo(GameManager.GetInstance().GetMap(), scatterTargetPoint);
            }

            return 1;
        }
    }
}
