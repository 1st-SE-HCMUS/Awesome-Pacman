using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    class OrangeGhost : Enemy
    {
        public OrangeGhost(Point startPoint)
        {
            MapPosition = startPoint;
            GraphicPosition = GameMap.ToGraphicPosition(MapPosition.X, MapPosition.Y);
        }
        protected override int AddSprite()
        {
            SpriteAct = new List<CharacterSprite>();
            List<Bitmap> up = new List<Bitmap>();
            List<Bitmap> down = new List<Bitmap>();
            List<Bitmap> left = new List<Bitmap>();
            List<Bitmap> right = new List<Bitmap>();

            up.Add(new Bitmap(Properties.Resources.orange__1_, CharacterSprite.Size, CharacterSprite.Size));
            up.Add(new Bitmap(Properties.Resources.orange__2_, CharacterSprite.Size, CharacterSprite.Size));

            down.Add(new Bitmap(Properties.Resources.orange__3_, CharacterSprite.Size, CharacterSprite.Size));
            down.Add(new Bitmap(Properties.Resources.orange__4_, CharacterSprite.Size, CharacterSprite.Size));

            left.Add(new Bitmap(Properties.Resources.orange__5_, CharacterSprite.Size, CharacterSprite.Size));
            left.Add(new Bitmap(Properties.Resources.orange__6_, CharacterSprite.Size, CharacterSprite.Size));

            right.Add(new Bitmap(Properties.Resources.orange__7_, CharacterSprite.Size, CharacterSprite.Size));
            right.Add(new Bitmap(Properties.Resources.orange__8_, CharacterSprite.Size, CharacterSprite.Size));


            SpriteAct.Add(new CharacterSprite(left));
            SpriteAct.Add(new CharacterSprite(right));
            SpriteAct.Add(new CharacterSprite(up));
            SpriteAct.Add(new CharacterSprite(down));


            return 0;
        }
    }
}
