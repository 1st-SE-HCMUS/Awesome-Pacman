using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    abstract class Enemy : Character
    {
        public int Score = 1500;

        public Enemy()
        {
            MapPosition = new Point(14, 15);
            GraphicPosition = GameMap.ToGraphicPosition(MapPosition.X, MapPosition.Y);
        }

        public override int Behave()
        {
            return 0;
            throw new NotImplementedException();
        }
    }
}
