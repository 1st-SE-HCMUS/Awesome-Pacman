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
            SpriteAct = new List<CharacterSprite>();
            List<Bitmap> up = new List<Bitmap>();
            List<Bitmap> down = new List<Bitmap>();
            List<Bitmap> left = new List<Bitmap>();
            List<Bitmap> right = new List<Bitmap>();
            List<Bitmap> dead = new List<Bitmap>();

            up.Add(new Bitmap(Properties.Resources.up__1_,CharacterSprite.Size, CharacterSprite.Size));
            up.Add(new Bitmap(Properties.Resources.up__2_,CharacterSprite.Size, CharacterSprite.Size));
            up.Add(new Bitmap(Properties.Resources.full,CharacterSprite.Size, CharacterSprite.Size));
            up.Add(new Bitmap(Properties.Resources.up__2_,CharacterSprite.Size, CharacterSprite.Size));

            down.Add(new Bitmap(Properties.Resources.down__1_,CharacterSprite.Size, CharacterSprite.Size));
            down.Add(new Bitmap(Properties.Resources.down__2_,CharacterSprite.Size, CharacterSprite.Size));
            down.Add(new Bitmap(Properties.Resources.full,CharacterSprite.Size, CharacterSprite.Size));
            down.Add(new Bitmap(Properties.Resources.down__2_,CharacterSprite.Size, CharacterSprite.Size));

            left.Add(new Bitmap(Properties.Resources.left__1_,CharacterSprite.Size, CharacterSprite.Size));
            left.Add(new Bitmap(Properties.Resources.left__2_,CharacterSprite.Size, CharacterSprite.Size));
            left.Add(new Bitmap(Properties.Resources.full,CharacterSprite.Size, CharacterSprite.Size));
            left.Add(new Bitmap(Properties.Resources.left__2_,CharacterSprite.Size, CharacterSprite.Size));

            right.Add(new Bitmap(Properties.Resources.right__1_,CharacterSprite.Size, CharacterSprite.Size));
            right.Add(new Bitmap(Properties.Resources.right__2_,CharacterSprite.Size, CharacterSprite.Size));
            right.Add(new Bitmap(Properties.Resources.full,CharacterSprite.Size, CharacterSprite.Size));
            right.Add(new Bitmap(Properties.Resources.right__2_,CharacterSprite.Size, CharacterSprite.Size));

            
            dead.Add(new Bitmap(Properties.Resources.dead__1_, CharacterSprite.Size, CharacterSprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__2_, CharacterSprite.Size, CharacterSprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__3_, CharacterSprite.Size, CharacterSprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__4_, CharacterSprite.Size, CharacterSprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__5_, CharacterSprite.Size, CharacterSprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__6_, CharacterSprite.Size, CharacterSprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__7_, CharacterSprite.Size, CharacterSprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__8_, CharacterSprite.Size, CharacterSprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__9_, CharacterSprite.Size, CharacterSprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__10_, CharacterSprite.Size, CharacterSprite.Size));
            dead.Add(new Bitmap(Properties.Resources.dead__11_, CharacterSprite.Size, CharacterSprite.Size));
            

            SpriteAct.Add(new CharacterSprite(left));
            SpriteAct.Add(new CharacterSprite(right));
            SpriteAct.Add(new CharacterSprite(up));
            SpriteAct.Add(new CharacterSprite(down));
            SpriteAct.Add(new CharacterSprite(dead));


            return 0;
        }

        public override int Animate(Graphics g)
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
