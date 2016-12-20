using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;

namespace PacMan
{
    class Pacman:Character
    {

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(UInt16 virtualKeyCode);
        private const UInt16 VK_LEFT = 0x25;
        private const UInt16 VK_RIGHT = 0x27;
        private const UInt16 VK_UP = 0x26;
        private const UInt16 VK_DOWN = 0x28;
        public override int Behave()
        {
            if((GetAsyncKeyState( VK_LEFT ) & 0x8000) != 0)
            {

                ChangeDirection(Direction.Left);
                return 0;
            }

            if((GetAsyncKeyState( VK_RIGHT ) & 0x8000) != 0)
            {
                ChangeDirection(Direction.Right);
                return 0;
            }

            if((GetAsyncKeyState( VK_UP ) & 0x8000) != 0)
            {
                ChangeDirection(Direction.Up);       
                return 0;
            }
            if ((GetAsyncKeyState(VK_DOWN) & 0x8000) != 0)
            {
                ChangeDirection(Direction.Down);
                return 0;
            }
            return 0;
        }

        public Pacman()
        {
            AddSprite();
        }
        protected override int AddSprite()
        {
            SpriteAct = new List<SpriteControl>();
            List<Bitmap> up = new List<Bitmap>();
            List<Bitmap> down = new List<Bitmap>();
            List<Bitmap> left = new List<Bitmap>();
            List<Bitmap> right = new List<Bitmap>();
            List<Bitmap> dead = new List<Bitmap>();

            up.Add(new Bitmap(Properties.Resources.up__1_,Constant.SpriteSize, Constant.SpriteSize));
            up.Add(new Bitmap(Properties.Resources.up__2_,Constant.SpriteSize, Constant.SpriteSize));
            up.Add(new Bitmap(Properties.Resources.full,Constant.SpriteSize, Constant.SpriteSize));
            up.Add(new Bitmap(Properties.Resources.up__2_,Constant.SpriteSize, Constant.SpriteSize));

            down.Add(new Bitmap(Properties.Resources.down__1_,Constant.SpriteSize, Constant.SpriteSize));
            down.Add(new Bitmap(Properties.Resources.down__2_,Constant.SpriteSize, Constant.SpriteSize));
            down.Add(new Bitmap(Properties.Resources.full,Constant.SpriteSize, Constant.SpriteSize));
            down.Add(new Bitmap(Properties.Resources.down__2_,Constant.SpriteSize, Constant.SpriteSize));

            left.Add(new Bitmap(Properties.Resources.left__1_,Constant.SpriteSize, Constant.SpriteSize));
            left.Add(new Bitmap(Properties.Resources.left__2_,Constant.SpriteSize, Constant.SpriteSize));
            left.Add(new Bitmap(Properties.Resources.full,Constant.SpriteSize, Constant.SpriteSize));
            left.Add(new Bitmap(Properties.Resources.left__2_,Constant.SpriteSize, Constant.SpriteSize));

            right.Add(new Bitmap(Properties.Resources.right__1_,Constant.SpriteSize, Constant.SpriteSize));
            right.Add(new Bitmap(Properties.Resources.right__2_,Constant.SpriteSize, Constant.SpriteSize));
            right.Add(new Bitmap(Properties.Resources.full,Constant.SpriteSize, Constant.SpriteSize));
            right.Add(new Bitmap(Properties.Resources.right__2_,Constant.SpriteSize, Constant.SpriteSize));

            
            dead.Add(new Bitmap(Properties.Resources.dead__1_, Constant.SpriteSize, Constant.SpriteSize));
            dead.Add(new Bitmap(Properties.Resources.dead__2_, Constant.SpriteSize, Constant.SpriteSize));
            dead.Add(new Bitmap(Properties.Resources.dead__3_, Constant.SpriteSize, Constant.SpriteSize));
            dead.Add(new Bitmap(Properties.Resources.dead__4_, Constant.SpriteSize, Constant.SpriteSize));
            dead.Add(new Bitmap(Properties.Resources.dead__5_, Constant.SpriteSize, Constant.SpriteSize));
            dead.Add(new Bitmap(Properties.Resources.dead__6_, Constant.SpriteSize, Constant.SpriteSize));
            dead.Add(new Bitmap(Properties.Resources.dead__7_, Constant.SpriteSize, Constant.SpriteSize));
            dead.Add(new Bitmap(Properties.Resources.dead__8_, Constant.SpriteSize, Constant.SpriteSize));
            dead.Add(new Bitmap(Properties.Resources.dead__9_, Constant.SpriteSize, Constant.SpriteSize));
            dead.Add(new Bitmap(Properties.Resources.dead__10_, Constant.SpriteSize, Constant.SpriteSize));
            dead.Add(new Bitmap(Properties.Resources.dead__11_, Constant.SpriteSize, Constant.SpriteSize));
            

            SpriteAct.Add(new SpriteControl(left));
            SpriteAct.Add(new SpriteControl(right));
            SpriteAct.Add(new SpriteControl(up));
            SpriteAct.Add(new SpriteControl(down));
            SpriteAct.Add(new SpriteControl(dead));


            return 0;
        }

        public override int Animate(Graphics g)
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
