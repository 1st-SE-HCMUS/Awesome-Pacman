using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    class SpriteControl
    {
        Bitmap[] _ListImage;
        int _ListSize;
        int _CurrSprite;
        Point _Position;

        public Bitmap[] ListImage
        {
            get
            {
                return _ListImage;
            }

            set
            {
                _ListImage = value;
                _ListSize = _ListImage.Length;
                _CurrSprite = 0;
            }
        }

        public int ListSize
        {
            get
            {
                return _ListSize;
            }

            set
            {
                _ListSize = value;
            }
        }

        public Point Position
        {
            get
            {
                return _Position;
            }

            set
            {
                _Position = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_listImage">List of sprites</param>
        /// <param name="_position">Position to draw each sprite</param>
        public SpriteControl(Bitmap[] _listImage, Point _position )
        {
            ListImage = _listImage;
            ListSize = _listImage.Count();
            Position = _position;
        }

        
        public SpriteControl(Bitmap[] _listImage, int _posX = 0, int _posY = 0) : this(_listImage, new Point(_posX, _posY))
        {
        }

        /// <summary>
        /// Draw current sprite than change current sprite index to next sprite
        /// </summary>
        /// <returns></returns>
        public int draw(Graphics g)
        {
            g.DrawImage(_ListImage[_CurrSprite], Position); 
            _CurrSprite = (_CurrSprite + 1) % _ListSize;
            return 0;
        }
    }
}
