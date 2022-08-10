using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    internal class Grid : Button
    {
        public bool isSnake { get; set; }
        public bool isFood { get; set; }
        public Color DefaultColor = Color.Silver;
        public Grid()
        {

        }
        public Grid(int SizeX, int SizeY, int StartX, int StartY)
        {
            this.Size = new System.Drawing.Size(SizeX, SizeY);
            this.Location = new System.Drawing.Point(StartX, StartY);
            this.isSnake = false;
            this.isFood = false;
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = this.DefaultColor;
            
        }
        public void SetSnake()
        {
            this.isSnake = true;
            this.BackColor = Color.Black;
        }
        public void SetFood()
        {
            this.isFood = true;
            this.BackColor= Color.Red;    
            
        }
        public void Reset()
        {
            this.isSnake = false;
            this.BackColor = DefaultColor;
            this.isFood= false;

        }

    }
}
