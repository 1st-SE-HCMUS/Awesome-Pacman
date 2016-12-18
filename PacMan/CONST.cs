using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{ 
    static class CONST
    {
        public const char WALL_CHAR = '+';
        public const char ROAD_CHAR = ' ';
        public const char BOUND_CHAR = '@';
        public const string PATH_FILE_MAP = @"D:\PacMan Map.txt";
        //public const Brush WALL_BRUSH = Brushes.AliceBlue;
        public const int SIZE_MAP_BLOCK = 15;
        public const float HAFT_SIZE_MAP_BLOCK = SIZE_MAP_BLOCK / 2 + 0.001f;
        public const float MAP_TOP_LEFT_X = 50; 
        public const float MAP_TOP_LEFT_Y = 50;
        public const int sizeSprite = 20;
    }
}
