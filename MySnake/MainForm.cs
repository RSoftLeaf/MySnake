//           Слава Україні           //
//           Героям Слава            //

namespace MySnake
{
    public partial class MainForm : Form
    {
        #region VARIABLES

        //Поле
        int DimX = 10;
        int DimY = 10;
        //Стартові параметри
        int SizeX = 30;
        int SizeY = 30;
        int LocationX = 10;
        int LocationY = 50;
        //Масиви ігрового поля
        Grid[,] Field;
        string Direction = "UP";
        List<SnakeCell> MySnake;
        //Round
        bool IsGame = true;
        bool GameOver = false;
        //await\async
        int TaskDelay = 1000;
        int iTemp = 2;

        #endregion
        public MainForm()
        {
            InitializeComponent();
            Initialize();
            timer1.Interval = TaskDelay;
        }
        public void StartNewGame()
        {
            NewSnakeSet();
            timer1.Start();
        }
        public void StopGame()
        {
            
        }
        public void SetFood()
        {
            Random randim = new Random();
            while (true)
            {
                int randimX = randim.Next(DimX);
                int randimY = randim.Next(DimY);
                if (!Field[randimX, randimY].isSnake) 
                { 
                    Field[randimX, randimY].SetFood(); 
                    break; 
                }
            } 

        }
        public void SnakeMove()
        {
            int x = MySnake[0].X;
            int y = MySnake[0].Y;
            switch (Direction)
            {
                case "UP":
                    {
                        if (Field[x,y - 1].isFood)
                            AddSnakeCell(x, y - 1, false);
                        else
                            AddSnakeCell(x, y - 1, true);
                        break;
                    }
                case "DOWN":
                    {
                        //
                        break;
                    }
            }
            
            iTemp += 1;
        }
        public void NewSnakeSet()
        {
            MySnake = new List<SnakeCell>();
            int StartX = DimX / 2;
            int StartY = DimY - 1;
            //await Task.Delay(TaskDelay);
            AddSnakeCell(StartX, StartY, false);
            //await Task.Delay(TaskDelay);
            AddSnakeCell(StartX, StartY - 1, false);
            //await Task.Delay(TaskDelay);
            AddSnakeCell(StartX, StartY - 2, false);
            //SetFood();
            Field[StartX, 3].SetFood();
        }
        public void AddSnakeCell(int x, int y, bool remove)
        {
            MySnake.Insert(0, new SnakeCell(x, y));
            Field[x, y].SetSnake();
            if (remove)
            {
                int lastX = MySnake[MySnake.Count - 1].X;
                int lastY = MySnake[MySnake.Count - 1].Y;
                MySnake.RemoveAt(MySnake.Count - 1);
                Field[lastX, lastY].Reset();
            }
        }
        public void Initialize()
        {
            #region PANEL INITIALIZE
            //============================================================



            //==========================================================*/
            #endregion

            #region FIELD INITIALIZE
            //============================================================
            
            Field = new Grid[DimX, DimY];

            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    Field[i, j] = new Grid(SizeX, SizeY, LocationX + SizeX * i, LocationY + SizeY * j);
                    this.Controls.Add(Field[i, j]);
                }
            }
            
            //==========================================================*/
            #endregion
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                Direction = "DOWN";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SnakeMove();

        }
    }
}