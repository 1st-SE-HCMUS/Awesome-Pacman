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

        public GameMap.Pos GetPosition()
        {
            return MapPosition;
        }

        public Pacman()
        {
            AddSprite();
        }
        protected override int AddSprite()
        {
            SpriteAct = new List<Sprite>();
            List<Bitmap> up = new List<Bitmap>();
            List<Bitmap> down = new List<Bitmap>();
            List<Bitmap> left = new List<Bitmap>();
            List<Bitmap> right = new List<Bitmap>();
            List<Bitmap> dead = new List<Bitmap>();

            up.Add(new Bitmap(Properties.Resources.up__1_,Sprite.Size, Sprite.Size));
            up.Add(new Bitmap(Properties.Resources.up__2_,Sprite.Size, Sprite.Size));
            up.Add(new Bitmap(Properties.Resources.full,Sprite.Size, Sprite.Size));
            up.Add(new Bitmap(Properties.Resources.up__2_,Sprite.Size, Sprite.Size));

            down.Add(new Bitmap(Properties.Resources.down__1_,Sprite.Size, Sprite.Size));
            down.Add(new Bitmap(Properties.Resources.down__2_,Sprite.Size, Sprite.Size));
            down.Add(new Bitmap(Properties.Resources.full,Sprite.Size, Sprite.Size));
            down.Add(new Bitmap(Properties.Resources.down__2_,Sprite.Size, Sprite.Size));

            left.Add(new Bitmap(Properties.Resources.left__1_,Sprite.Size, Sprite.Size));
            left.Add(new Bitmap(Properties.Resources.left__2_,Sprite.Size, Sprite.Size));
            left.Add(new Bitmap(Properties.Resources.full,Sprite.Size, Sprite.Size));
            left.Add(new Bitmap(Properties.Resources.left__2_,Sprite.Size, Sprite.Size));

            right.Add(new Bitmap(Properties.Resources.right__1_,Sprite.Size, Sprite.Size));
            right.Add(new Bitmap(Properties.Resources.right__2_,Sprite.Size, Sprite.Size));
            right.Add(new Bitmap(Properties.Resources.full,Sprite.Size, Sprite.Size));
            right.Add(new Bitmap(Properties.Resources.right__2_,Sprite.Size, Sprite.Size));

            
            dead.Add(new Bitmap(Properties.Resources.dead__1_, Sprite.Size, Sprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__2_, Sprite.Size, Sprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__3_, Sprite.Size, Sprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__4_, Sprite.Size, Sprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__5_, Sprite.Size, Sprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__6_, Sprite.Size, Sprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__7_, Sprite.Size, Sprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__8_, Sprite.Size, Sprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__9_, Sprite.Size, Sprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__10_, Sprite.Size, Sprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__11_, Sprite.Size, Sprite.Size));
            

            SpriteAct.Add(new Sprite(left));
            SpriteAct.Add(new Sprite(right));
            SpriteAct.Add(new Sprite(up));
            SpriteAct.Add(new Sprite(down));
            SpriteAct.Add(new Sprite(dead));


            return 0;
        }

        public override int Animate(Graphics g)
        {
            PointF drawPoint = new PointF(GraphicPosition.X - Sprite.Size / 2, GraphicPosition.Y - Sprite.Size / 2);

            if (State == CharacterState.Died)//for pacman only
            {
                if(SpriteAct[4].CurrSprite == SpriteAct[4].ListImage.Count - 1)
                {
                    State = CharacterState.NeedDestroy;
                    return 1;//game over
                }
                SpriteAct[4].draw(g, drawPoint);
                return 0;
            }
            //else
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
