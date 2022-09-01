using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    internal class SnakeRecord
    {
        public string username { get; set; }
        public int snakeLength { get; set; }
        public SnakeRecord(string Username, int SnakeLength)
        {
            username = Username;
            snakeLength = SnakeLength;
        }
    }
}
