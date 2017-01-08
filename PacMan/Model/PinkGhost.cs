using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    class PinkGhost : Enemy
    {
        public PinkGhost(GameMap.Pos startPoint)
        {
            MapPosition = startPoint;
            GraphicPosition = GameMap.ToGraphicPosition(MapPosition.Y, MapPosition.X);
        }
        protected override int AddSprite()
        {
            SpriteAct = new List<CharacterSprite>();
            List<Bitmap> up = new List<Bitmap>();
            List<Bitmap> down = new List<Bitmap>();
            List<Bitmap> left = new List<Bitmap>();
            List<Bitmap> right = new List<Bitmap>();

            up.Add(new Bitmap(Properties.Resources.pink__1_, CharacterSprite.Size, CharacterSprite.Size));
            up.Add(new Bitmap(Properties.Resources.pink__2_, CharacterSprite.Size, CharacterSprite.Size));

            down.Add(new Bitmap(Properties.Resources.pink__3_, CharacterSprite.Size, CharacterSprite.Size));
            down.Add(new Bitmap(Properties.Resources.pink__5_, CharacterSprite.Size, CharacterSprite.Size));

            left.Add(new Bitmap(Properties.Resources.pink__6_, CharacterSprite.Size, CharacterSprite.Size));
            left.Add(new Bitmap(Properties.Resources.pink__8_, CharacterSprite.Size, CharacterSprite.Size));

            right.Add(new Bitmap(Properties.Resources.pink__7_, CharacterSprite.Size, CharacterSprite.Size));
            right.Add(new Bitmap(Properties.Resources.pink__4_, CharacterSprite.Size, CharacterSprite.Size));


            SpriteAct.Add(new CharacterSprite(left));
            SpriteAct.Add(new CharacterSprite(right));
            SpriteAct.Add(new CharacterSprite(up));
            SpriteAct.Add(new CharacterSprite(down));


            return 0;
        }

        public override int Behave()
        {
            GameManager manager = GameManager.GetInstance();
            if (Mode == EnemyMode.Chase)
            {
                //
                return ChooseWayToGo(manager.GetMap(), manager.GetPacmanPosition());
            }
            else if (Mode == EnemyMode.Scatter)
            {
                //Scatter
                return ChooseWayToGo(manager.GetMap(), new GameMap.Pos(35, 2));
            }
            // Fuck..., no way to pacman
            else
            {
                //Pissed mode
                return 0;
            }
        }
    }
}
