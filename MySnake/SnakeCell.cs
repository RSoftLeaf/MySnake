using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    internal class SnakeCell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public SnakeCell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
