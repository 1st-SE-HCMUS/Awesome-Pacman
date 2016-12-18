using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    abstract class Character_Enemy:Character
    {
        protected int Score;

        public Character_Enemy()
        {
            PosMap = new Point(14,15);
            PosGraph = PosMapToGraphic(PosMap.X, PosMap.Y);
        }
       
        public override int behave()
        {
            return 0;
            throw new NotImplementedException();
        }
    }

    class Character_Enemy_Red:Character_Enemy
    {
        public Character_Enemy_Red(Point startPoint)
        {
            PosMap = startPoint;
            PosGraph = PosMapToGraphic(PosMap.X, PosMap.Y);
        }
        protected override int addSprite()
        {
            SpriteAct = new List<SpriteControl>();
            List<Bitmap> up = new List<Bitmap>();
            List<Bitmap> down = new List<Bitmap>();
            List<Bitmap> left = new List<Bitmap>();
            List<Bitmap> right = new List<Bitmap>();

            up.Add(new Bitmap(Properties.Resources.red__1_, CONST.sizeSprite, CONST.sizeSprite));
            up.Add(new Bitmap(Properties.Resources.red__2_, CONST.sizeSprite, CONST.sizeSprite));

            down.Add(new Bitmap(Properties.Resources.red__3_, CONST.sizeSprite, CONST.sizeSprite));
            down.Add(new Bitmap(Properties.Resources.red__4_, CONST.sizeSprite, CONST.sizeSprite));

            left.Add(new Bitmap(Properties.Resources.red__5_, CONST.sizeSprite, CONST.sizeSprite));
            left.Add(new Bitmap(Properties.Resources.red__6_, CONST.sizeSprite, CONST.sizeSprite));

            right.Add(new Bitmap(Properties.Resources.red__7_, CONST.sizeSprite, CONST.sizeSprite));
            right.Add(new Bitmap(Properties.Resources.red__8_, CONST.sizeSprite, CONST.sizeSprite));


            SpriteAct.Add(new SpriteControl(left));
            SpriteAct.Add(new SpriteControl(right));
            SpriteAct.Add(new SpriteControl(up));
            SpriteAct.Add(new SpriteControl(down));


            return 0;
        }

    }
    class Character_Enemy_Pink : Character_Enemy
    {
        public Character_Enemy_Pink(Point startPoint)
        {
            PosMap = startPoint;
            PosGraph = PosMapToGraphic(PosMap.X, PosMap.Y);
        }
        protected override int addSprite()
        {
            SpriteAct = new List<SpriteControl>();
            List<Bitmap> up = new List<Bitmap>();
            List<Bitmap> down = new List<Bitmap>();
            List<Bitmap> left = new List<Bitmap>();
            List<Bitmap> right = new List<Bitmap>();

            up.Add(new Bitmap(Properties.Resources.pink__1_, CONST.sizeSprite, CONST.sizeSprite));
            up.Add(new Bitmap(Properties.Resources.pink__2_, CONST.sizeSprite, CONST.sizeSprite));

            down.Add(new Bitmap(Properties.Resources.pink__3_, CONST.sizeSprite, CONST.sizeSprite));
            down.Add(new Bitmap(Properties.Resources.pink__5_, CONST.sizeSprite, CONST.sizeSprite));

            left.Add(new Bitmap(Properties.Resources.pink__6_, CONST.sizeSprite, CONST.sizeSprite));
            left.Add(new Bitmap(Properties.Resources.pink__8_, CONST.sizeSprite, CONST.sizeSprite));

            right.Add(new Bitmap(Properties.Resources.pink__7_, CONST.sizeSprite, CONST.sizeSprite));
            right.Add(new Bitmap(Properties.Resources.pink__4_, CONST.sizeSprite, CONST.sizeSprite));


            SpriteAct.Add(new SpriteControl(left));
            SpriteAct.Add(new SpriteControl(right));
            SpriteAct.Add(new SpriteControl(up));
            SpriteAct.Add(new SpriteControl(down));


            return 0;
        }
    }
    class Character_Enemy_Blue : Character_Enemy
    {
        public Character_Enemy_Blue(Point startPoint)
        {
            PosMap = startPoint;
            PosGraph = PosMapToGraphic(PosMap.X, PosMap.Y);
        }
        protected override int addSprite()
        {
            SpriteAct = new List<SpriteControl>();
            List<Bitmap> up = new List<Bitmap>();
            List<Bitmap> down = new List<Bitmap>();
            List<Bitmap> left = new List<Bitmap>();
            List<Bitmap> right = new List<Bitmap>();

            up.Add(new Bitmap(Properties.Resources.blue__1_, CONST.sizeSprite, CONST.sizeSprite));
            up.Add(new Bitmap(Properties.Resources.blue__2_, CONST.sizeSprite, CONST.sizeSprite));

            down.Add(new Bitmap(Properties.Resources.blue__3_, CONST.sizeSprite, CONST.sizeSprite));
            down.Add(new Bitmap(Properties.Resources.blue__4_, CONST.sizeSprite, CONST.sizeSprite));

            left.Add(new Bitmap(Properties.Resources.blue__5_, CONST.sizeSprite, CONST.sizeSprite));
            left.Add(new Bitmap(Properties.Resources.blue__6_, CONST.sizeSprite, CONST.sizeSprite));

            right.Add(new Bitmap(Properties.Resources.blue__7_, CONST.sizeSprite, CONST.sizeSprite));
            right.Add(new Bitmap(Properties.Resources.blue__8_, CONST.sizeSprite, CONST.sizeSprite));


            SpriteAct.Add(new SpriteControl(left));
            SpriteAct.Add(new SpriteControl(right));
            SpriteAct.Add(new SpriteControl(up));
            SpriteAct.Add(new SpriteControl(down));


            return 0;
        }
    }
    class Character_Enemy_Orange : Character_Enemy
    {
        public Character_Enemy_Orange(Point startPoint)
        {
            PosMap = startPoint;
            PosGraph = PosMapToGraphic(PosMap.X, PosMap.Y);
        }
        protected override int addSprite()
        {
            SpriteAct = new List<SpriteControl>();
            List<Bitmap> up = new List<Bitmap>();
            List<Bitmap> down = new List<Bitmap>();
            List<Bitmap> left = new List<Bitmap>();
            List<Bitmap> right = new List<Bitmap>();

            up.Add(new Bitmap(Properties.Resources.orange__1_, CONST.sizeSprite, CONST.sizeSprite));
            up.Add(new Bitmap(Properties.Resources.orange__2_, CONST.sizeSprite, CONST.sizeSprite));

            down.Add(new Bitmap(Properties.Resources.orange__3_, CONST.sizeSprite, CONST.sizeSprite));
            down.Add(new Bitmap(Properties.Resources.orange__4_, CONST.sizeSprite, CONST.sizeSprite));

            left.Add(new Bitmap(Properties.Resources.orange__5_, CONST.sizeSprite, CONST.sizeSprite));
            left.Add(new Bitmap(Properties.Resources.orange__6_, CONST.sizeSprite, CONST.sizeSprite));

            right.Add(new Bitmap(Properties.Resources.orange__7_, CONST.sizeSprite, CONST.sizeSprite));
            right.Add(new Bitmap(Properties.Resources.orange__8_, CONST.sizeSprite, CONST.sizeSprite));


            SpriteAct.Add(new SpriteControl(left));
            SpriteAct.Add(new SpriteControl(right));
            SpriteAct.Add(new SpriteControl(up));
            SpriteAct.Add(new SpriteControl(down));


            return 0;
        }
    }
}
