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
        int Margin = 1;
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
        //Timer
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        //Cheat Commands
        bool god = false;

        #endregion
        public MainForm()
        {
            InitializeComponent();
            Initialize();
            timer1.Interval = TaskDelay;
            StartNewGame();
        }
        public void StartNewGame()
        {
            NewSnakeSet();
            timer1.Start();
        }
        public void StopGame()
        {
            timer1.Stop();
            MessageBox.Show("Проигрыш", "Сообщение");
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
            int MaxX = Field.GetLength(0) - 1;
            int MaxY = Field.GetLength(1) - 1;
            god = true;
            int x = MySnake[0].X;
            int y = MySnake[0].Y;
            //  MessageBox.Show("x: " + x + ";y: " + y);
            switch (Direction)
            {
                case "UP":
                    {
                        if (!Field[x, y - 1].isSnake)
                        {
                            if (y == 0)
                            {
                                if (!god)
                                    StopGame();
                                else
                                {
                                    if (Field[x, MaxY].isFood)
                                        AddSnakeCell(x, MaxY, false, true);
                                    else
                                        AddSnakeCell(x, MaxY, true, false);

                                }

                            }
                            else
                            {
                                if (Field[x, y - 1].isFood)
                                    AddSnakeCell(x, y - 1, false, true);
                                else
                                    AddSnakeCell(x, y - 1, true, false);
                            }
                        }
                        else
                        {
                            StopGame();
                        }
                        break;
                    }
                case "DOWN":
                    {
                        if (!Field[x, y + 1].isSnake)
                        {
                            if (y == MaxY)
                            {
                                if (!god)
                                    StopGame();
                                else
                                {
                                    if (Field[x, 0].isFood)
                                        AddSnakeCell(x, 0, false, true);
                                    else
                                        AddSnakeCell(x, 0, true, false);

                                }

                            }
                            else
                            {
                                if (Field[x, y + 1].isFood)
                                    AddSnakeCell(x, y + 1, false, true);
                                else
                                    AddSnakeCell(x, y + 1, true, false);
                            }
                        }
                        else
                        {
                            StopGame();
                        }
                        break;
                    }
                case "LEFT":
                    {
                        if (!Field[x - 1, y].isSnake)
                        {
                            if (x == 0)
                            {
                                if (!god)
                                    StopGame();
                                else
                                {
                                    if (Field[MaxX, y].isFood)
                                        AddSnakeCell(MaxX, y, false, true);
                                    else
                                        AddSnakeCell(MaxX, y, true, false);

                                }

                            }
                            else
                            {
                                if (Field[x - 1, y].isFood)
                                    AddSnakeCell(x - 1, y, false, true);
                                else
                                    AddSnakeCell(x - 1, y, true, false);
                            }
                        }
                        else
                        {
                            StopGame();
                        }
                        break;
                    }
                case "RIGHT":
                    {
                        if (!Field[x + 1, y].isSnake)
                        {
                            if (x == MaxX)
                            {
                                if (!god)
                                    StopGame();
                                else
                                {
                                    if (Field[0, y].isFood)
                                        AddSnakeCell(0, y, false, true);
                                    else
                                        AddSnakeCell(0, y, true, false);

                                }

                            }
                            else
                            {
                                if (Field[x + 1, y].isFood)
                                    AddSnakeCell(x + 1, y, false, true);
                                else
                                    AddSnakeCell(x + 1, y, true, false);
                            }
                        }
                        else
                        {
                            StopGame();
                        }
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
            AddSnakeCell(StartX, StartY, false, false);
            //await Task.Delay(TaskDelay);
            AddSnakeCell(StartX, StartY - 1, false, false);
            //await Task.Delay(TaskDelay);
            AddSnakeCell(StartX, StartY - 2, false, false);
            SetFood();
        }
        public void AddSnakeCell(int x, int y, bool remove, bool food)
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
            if (food)
            {
                SetFood();
            }
        }
        public void Initialize()
        {
            #region EMPTY
            //============================================================



            //==========================================================*/
            #endregion

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
                    Field[i, j] = new Grid(SizeX, SizeY, LocationX + (SizeX + Margin) * i, LocationY + (SizeY + Margin) * j);
                    this.Controls.Add(Field[i, j]);
                }
            }

            //==========================================================*/
            #endregion

            #region TIMER INITIALIZE
            //============================================================

            timer1.Tick += new System.EventHandler(timer1_Tick);

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
        //
        //CODE
        //
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                if (Direction != "DOWN")
                    Direction = "UP";
                return true;
            }
            if (keyData == Keys.Down)
            {
                if (Direction != "UP")
                    Direction = "DOWN";
                return true;
            }
            if (keyData == Keys.Left)
            {
                if (Direction != "RIGHT")
                    Direction = "LEFT";
                return true;
            }
            if (keyData == Keys.Right)
            {
                if (Direction != "LEFT")
                    Direction = "RIGHT";
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SnakeMove();
        }
    }
}