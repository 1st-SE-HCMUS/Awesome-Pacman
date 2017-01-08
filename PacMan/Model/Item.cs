using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Model
{
    class Item
    {
        public int Score = 100;
        public Point MapPosition = new Point(5, 2); // current position in map(has bounds)
        public Sprite ItemSprite;
        

        public Item(Sprite itemSprite)
        {
            ItemSprite = itemSprite;
        }
        
    }
}
