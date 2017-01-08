using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    class RedGhost:Enemy
    {
        public RedGhost(Point startPoint)
        {
            MapPosition = startPoint;
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

            up.Add(new Bitmap(Properties.Resources.red__1_, Sprite.Size, Sprite.Size));
            up.Add(new Bitmap(Properties.Resources.red__2_, Sprite.Size, Sprite.Size));

            down.Add(new Bitmap(Properties.Resources.red__3_, Sprite.Size, Sprite.Size));
            down.Add(new Bitmap(Properties.Resources.red__4_, Sprite.Size, Sprite.Size));

            left.Add(new Bitmap(Properties.Resources.red__5_, Sprite.Size, Sprite.Size));
            left.Add(new Bitmap(Properties.Resources.red__6_, Sprite.Size, Sprite.Size));

            right.Add(new Bitmap(Properties.Resources.red__7_, Sprite.Size, Sprite.Size));
            right.Add(new Bitmap(Properties.Resources.red__8_, Sprite.Size, Sprite.Size));


            SpriteAct.Add(new Sprite(left));
            SpriteAct.Add(new Sprite(right));
            SpriteAct.Add(new Sprite(up));
            SpriteAct.Add(new Sprite(down));
            SpriteAct.Add(new Sprite(afraid));
            SpriteAct.Add(new Sprite(blink));


            return 0;
        }
    }
}
