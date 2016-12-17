using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices;

namespace PacMan
{
    class PacmanControl:Character
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
    }
}
