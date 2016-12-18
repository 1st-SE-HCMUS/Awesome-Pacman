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
    class Character_Pacman:Character
    {

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(UInt16 virtualKeyCode);
        private const UInt16 VK_LEFT = 0x25;
        private const UInt16 VK_RIGHT = 0x27;
        private const UInt16 VK_UP = 0x26;
        private const UInt16 VK_DOWN = 0x28;
        public override int behave()
        {
            if((GetAsyncKeyState( VK_LEFT ) & 0x8000) != 0)
            {

                changeDirection(DIRECTION.Left);
                return 0;
            }

            if((GetAsyncKeyState( VK_RIGHT ) & 0x8000) != 0)
            {
                changeDirection(DIRECTION.Right);
                return 0;
            }

            if((GetAsyncKeyState( VK_UP ) & 0x8000) != 0)
            {
                changeDirection(DIRECTION.Up);       
                return 0;
            }
            if ((GetAsyncKeyState(VK_DOWN) & 0x8000) != 0)
            {
                changeDirection(DIRECTION.Down);
                return 0;
            }
            return 0;
        }

        public Character_Pacman()
        {
            addSprite();
        }
        protected override int addSprite()
        {
            SpriteAct = new List<SpriteControl>();
            List<Bitmap> up = new List<Bitmap>();
            List<Bitmap> down = new List<Bitmap>();
            List<Bitmap> left = new List<Bitmap>();
            List<Bitmap> right = new List<Bitmap>();
            List<Bitmap> dead = new List<Bitmap>();

            up.Add(new Bitmap(Properties.Resources.up__1_,CONST.sizeSprite, CONST.sizeSprite));
            up.Add(new Bitmap(Properties.Resources.up__2_,CONST.sizeSprite, CONST.sizeSprite));
            up.Add(new Bitmap(Properties.Resources.full,CONST.sizeSprite, CONST.sizeSprite));
            up.Add(new Bitmap(Properties.Resources.up__2_,CONST.sizeSprite, CONST.sizeSprite));

            down.Add(new Bitmap(Properties.Resources.down__1_,CONST.sizeSprite, CONST.sizeSprite));
            down.Add(new Bitmap(Properties.Resources.down__2_,CONST.sizeSprite, CONST.sizeSprite));
            down.Add(new Bitmap(Properties.Resources.full,CONST.sizeSprite, CONST.sizeSprite));
            down.Add(new Bitmap(Properties.Resources.down__2_,CONST.sizeSprite, CONST.sizeSprite));

            left.Add(new Bitmap(Properties.Resources.left__1_,CONST.sizeSprite, CONST.sizeSprite));
            left.Add(new Bitmap(Properties.Resources.left__2_,CONST.sizeSprite, CONST.sizeSprite));
            left.Add(new Bitmap(Properties.Resources.full,CONST.sizeSprite, CONST.sizeSprite));
            left.Add(new Bitmap(Properties.Resources.left__2_,CONST.sizeSprite, CONST.sizeSprite));

            right.Add(new Bitmap(Properties.Resources.right__1_,CONST.sizeSprite, CONST.sizeSprite));
            right.Add(new Bitmap(Properties.Resources.right__2_,CONST.sizeSprite, CONST.sizeSprite));
            right.Add(new Bitmap(Properties.Resources.full,CONST.sizeSprite, CONST.sizeSprite));
            right.Add(new Bitmap(Properties.Resources.right__2_,CONST.sizeSprite, CONST.sizeSprite));

            
            dead.Add(new Bitmap(Properties.Resources.dead__1_, CONST.sizeSprite, CONST.sizeSprite));
            dead.Add(new Bitmap(Properties.Resources.dead__2_, CONST.sizeSprite, CONST.sizeSprite));
            dead.Add(new Bitmap(Properties.Resources.dead__3_, CONST.sizeSprite, CONST.sizeSprite));
            dead.Add(new Bitmap(Properties.Resources.dead__4_, CONST.sizeSprite, CONST.sizeSprite));
            dead.Add(new Bitmap(Properties.Resources.dead__5_, CONST.sizeSprite, CONST.sizeSprite));
            dead.Add(new Bitmap(Properties.Resources.dead__6_, CONST.sizeSprite, CONST.sizeSprite));
            dead.Add(new Bitmap(Properties.Resources.dead__7_, CONST.sizeSprite, CONST.sizeSprite));
            dead.Add(new Bitmap(Properties.Resources.dead__8_, CONST.sizeSprite, CONST.sizeSprite));
            dead.Add(new Bitmap(Properties.Resources.dead__9_, CONST.sizeSprite, CONST.sizeSprite));
            dead.Add(new Bitmap(Properties.Resources.dead__10_, CONST.sizeSprite, CONST.sizeSprite));
            dead.Add(new Bitmap(Properties.Resources.dead__11_, CONST.sizeSprite, CONST.sizeSprite));
            

            SpriteAct.Add(new SpriteControl(left));
            SpriteAct.Add(new SpriteControl(right));
            SpriteAct.Add(new SpriteControl(up));
            SpriteAct.Add(new SpriteControl(down));
            SpriteAct.Add(new SpriteControl(dead));


            return 0;
        }

        public override int animate(Graphics g)
        {
            PointF drawPoint = new PointF(PosGraph.X - CONST.sizeSprite / 2, PosGraph.Y - CONST.sizeSprite / 2);
            
            switch (CurrDirection)
            {
                case DIRECTION.Left:
                    {
                        SpriteAct[0].draw(g, drawPoint);
                        break;
                    }
                case DIRECTION.Right:
                    {
                        SpriteAct[1].draw(g, drawPoint);
                        break;
                    }
                case DIRECTION.Up:
                    {
                        SpriteAct[2].draw(g, drawPoint);
                        break;
                    }
                case DIRECTION.Down:
                    {
                        SpriteAct[3].draw(g, drawPoint);
                        break;
                    }
            }
            return 0;
        }
    }
}
