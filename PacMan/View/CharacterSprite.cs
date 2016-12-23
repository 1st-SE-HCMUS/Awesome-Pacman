using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    class CharacterSprite
    {
        public const int Size = 20;
        private List<Bitmap> _ListImage;
     
        int CurrSprite;
        public CharacterSprite(List<Bitmap> _listImage)
        {
            ListImage = _listImage;
            CurrSprite = 0;
        }

        public List<Bitmap> ListImage
        {
            get
            {
                return _ListImage;
            }

            set
            {
                _ListImage = value;
                CurrSprite = 0;
            }
        }
        
        /// <summary>
        /// Draw current sprite than change current sprite index to next sprite
        /// </summary>
        /// <returns></returns>
        public int draw(Graphics g, PointF position)
        {
            g.DrawImage(ListImage[CurrSprite], position); 
            CurrSprite = (CurrSprite + 1) % ListImage.Count;
            return 0;
        }
    }
}
