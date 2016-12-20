using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    abstract class Enemy:Character
    {
        protected int Score;

        public Enemy()
        {
            PosMap = new Point(14,15);
            PosGraph = PosMapToGraphic(PosMap.X, PosMap.Y);
        }
       
        public override int Behave()
        {
            return 0;
            throw new NotImplementedException();
        }
    }

    class EnemyRed:Enemy
    {
        public EnemyRed(Point startPoint)
        {
            PosMap = startPoint;
            PosGraph = PosMapToGraphic(PosMap.X, PosMap.Y);
        }
        protected override int AddSprite()
        {
            SpriteAct = new List<SpriteControl>();
            List<Bitmap> up = new List<Bitmap>();
            List<Bitmap> down = new List<Bitmap>();
            List<Bitmap> left = new List<Bitmap>();
            List<Bitmap> right = new List<Bitmap>();

            up.Add(new Bitmap(Properties.Resources.red__1_, Constant.SpriteSize, Constant.SpriteSize));
            up.Add(new Bitmap(Properties.Resources.red__2_, Constant.SpriteSize, Constant.SpriteSize));

            down.Add(new Bitmap(Properties.Resources.red__3_, Constant.SpriteSize, Constant.SpriteSize));
            down.Add(new Bitmap(Properties.Resources.red__4_, Constant.SpriteSize, Constant.SpriteSize));

            left.Add(new Bitmap(Properties.Resources.red__5_, Constant.SpriteSize, Constant.SpriteSize));
            left.Add(new Bitmap(Properties.Resources.red__6_, Constant.SpriteSize, Constant.SpriteSize));

            right.Add(new Bitmap(Properties.Resources.red__7_, Constant.SpriteSize, Constant.SpriteSize));
            right.Add(new Bitmap(Properties.Resources.red__8_, Constant.SpriteSize, Constant.SpriteSize));


            SpriteAct.Add(new SpriteControl(left));
            SpriteAct.Add(new SpriteControl(right));
            SpriteAct.Add(new SpriteControl(up));
            SpriteAct.Add(new SpriteControl(down));


            return 0;
        }

    }
    class EnemyPink : Enemy
    {
        public EnemyPink(Point startPoint)
        {
            PosMap = startPoint;
            PosGraph = PosMapToGraphic(PosMap.X, PosMap.Y);
        }
        protected override int AddSprite()
        {
            SpriteAct = new List<SpriteControl>();
            List<Bitmap> up = new List<Bitmap>();
            List<Bitmap> down = new List<Bitmap>();
            List<Bitmap> left = new List<Bitmap>();
            List<Bitmap> right = new List<Bitmap>();

            up.Add(new Bitmap(Properties.Resources.pink__1_, Constant.SpriteSize, Constant.SpriteSize));
            up.Add(new Bitmap(Properties.Resources.pink__2_, Constant.SpriteSize, Constant.SpriteSize));

            down.Add(new Bitmap(Properties.Resources.pink__3_, Constant.SpriteSize, Constant.SpriteSize));
            down.Add(new Bitmap(Properties.Resources.pink__5_, Constant.SpriteSize, Constant.SpriteSize));

            left.Add(new Bitmap(Properties.Resources.pink__6_, Constant.SpriteSize, Constant.SpriteSize));
            left.Add(new Bitmap(Properties.Resources.pink__8_, Constant.SpriteSize, Constant.SpriteSize));

            right.Add(new Bitmap(Properties.Resources.pink__7_, Constant.SpriteSize, Constant.SpriteSize));
            right.Add(new Bitmap(Properties.Resources.pink__4_, Constant.SpriteSize, Constant.SpriteSize));


            SpriteAct.Add(new SpriteControl(left));
            SpriteAct.Add(new SpriteControl(right));
            SpriteAct.Add(new SpriteControl(up));
            SpriteAct.Add(new SpriteControl(down));


            return 0;
        }
    }
    class EnemyBlue : Enemy
    {
        public EnemyBlue(Point startPoint)
        {
            PosMap = startPoint;
            PosGraph = PosMapToGraphic(PosMap.X, PosMap.Y);
        }
        protected override int AddSprite()
        {
            SpriteAct = new List<SpriteControl>();
            List<Bitmap> up = new List<Bitmap>();
            List<Bitmap> down = new List<Bitmap>();
            List<Bitmap> left = new List<Bitmap>();
            List<Bitmap> right = new List<Bitmap>();

            up.Add(new Bitmap(Properties.Resources.blue__1_, Constant.SpriteSize, Constant.SpriteSize));
            up.Add(new Bitmap(Properties.Resources.blue__2_, Constant.SpriteSize, Constant.SpriteSize));

            down.Add(new Bitmap(Properties.Resources.blue__3_, Constant.SpriteSize, Constant.SpriteSize));
            down.Add(new Bitmap(Properties.Resources.blue__4_, Constant.SpriteSize, Constant.SpriteSize));

            left.Add(new Bitmap(Properties.Resources.blue__5_, Constant.SpriteSize, Constant.SpriteSize));
            left.Add(new Bitmap(Properties.Resources.blue__6_, Constant.SpriteSize, Constant.SpriteSize));

            right.Add(new Bitmap(Properties.Resources.blue__7_, Constant.SpriteSize, Constant.SpriteSize));
            right.Add(new Bitmap(Properties.Resources.blue__8_, Constant.SpriteSize, Constant.SpriteSize));


            SpriteAct.Add(new SpriteControl(left));
            SpriteAct.Add(new SpriteControl(right));
            SpriteAct.Add(new SpriteControl(up));
            SpriteAct.Add(new SpriteControl(down));


            return 0;
        }
    }
    class EnemyOrange : Enemy
    {
        public EnemyOrange(Point startPoint)
        {
            PosMap = startPoint;
            PosGraph = PosMapToGraphic(PosMap.X, PosMap.Y);
        }
        protected override int AddSprite()
        {
            SpriteAct = new List<SpriteControl>();
            List<Bitmap> up = new List<Bitmap>();
            List<Bitmap> down = new List<Bitmap>();
            List<Bitmap> left = new List<Bitmap>();
            List<Bitmap> right = new List<Bitmap>();

            up.Add(new Bitmap(Properties.Resources.orange__1_, Constant.SpriteSize, Constant.SpriteSize));
            up.Add(new Bitmap(Properties.Resources.orange__2_, Constant.SpriteSize, Constant.SpriteSize));

            down.Add(new Bitmap(Properties.Resources.orange__3_, Constant.SpriteSize, Constant.SpriteSize));
            down.Add(new Bitmap(Properties.Resources.orange__4_, Constant.SpriteSize, Constant.SpriteSize));

            left.Add(new Bitmap(Properties.Resources.orange__5_, Constant.SpriteSize, Constant.SpriteSize));
            left.Add(new Bitmap(Properties.Resources.orange__6_, Constant.SpriteSize, Constant.SpriteSize));

            right.Add(new Bitmap(Properties.Resources.orange__7_, Constant.SpriteSize, Constant.SpriteSize));
            right.Add(new Bitmap(Properties.Resources.orange__8_, Constant.SpriteSize, Constant.SpriteSize));


            SpriteAct.Add(new SpriteControl(left));
            SpriteAct.Add(new SpriteControl(right));
            SpriteAct.Add(new SpriteControl(up));
            SpriteAct.Add(new SpriteControl(down));


            return 0;
        }
    }
}
