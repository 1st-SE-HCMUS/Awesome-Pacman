using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{ 
    static class Constant
    {
        //Constant field should be named in PascalCase
        public const char WallChar = '+';
        public const char RoadChar = ' ';
        public const char BoundChar = '@';
        public const string MapFilePath = @"D:\PacMan Map.txt";
        //public const Brush WALL_BRUSH = Brushes.AliceBlue;
        public const int MapBlockSize = 15;
        public const float HalfMapBlockSize = MapBlockSize / 2 + 0.001f;
        public const float MapTopLeftX = 50; 
        public const float MapTopLeftY = 50;
        public const int SpriteSize = 20;
    }
}
