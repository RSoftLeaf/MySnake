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
        bool god = true;
        //Command
        string command;
        //Snake length

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
            //god = true;
            int x = MySnake[0].X;
            int y = MySnake[0].Y;
            //  MessageBox.Show("x: " + x + ";y: " + y);
            switch (Direction)
            {
                case "UP":
                    {
                        if (y == 0)
                        {
                            if (god)
                            {
                                if (Field[x, MaxY].isFood)
                                    AddSnakeCell(x, MaxY, false, true);
                                else
                                    AddSnakeCell(x, MaxY, true, false);
                            }
                            else
                            {
                                StopGame();
                            }
                        }
                        else
                        {
                            if (Field[x, y - 1].isSnake)
                            {
                                StopGame();
                            }
                            else if (Field[x, y - 1].isFood)
                                AddSnakeCell(x, y - 1, false, true);
                            else
                                AddSnakeCell(x, y - 1, true, false);

                        }

                        break;
                    }
                case "DOWN":
                    {
                        if (y == MaxY)
                        {
                            if (god)
                            {
                                if (Field[x, 0].isFood)
                                    AddSnakeCell(x, 0, false, true);
                                else
                                    AddSnakeCell(x, 0, true, false);
                            }
                            else
                            {
                                StopGame();
                            }
                        }
                        else
                        {
                            if (Field[x, y + 1].isSnake)
                            {
                                StopGame();
                            }
                            else if (Field[x, y + 1].isFood)
                                AddSnakeCell(x, y + 1, false, true);
                            else
                                AddSnakeCell(x, y + 1, true, false);

                        }
                        break;
                    }
                case "LEFT":
                    {
                        if (x == 0)
                        {
                            if (god)
                            {
                                if (Field[MaxX, y].isFood)
                                    AddSnakeCell(MaxX, y, false, true);
                                else
                                    AddSnakeCell(MaxX, y, true, false);
                            }
                            else
                            {
                                StopGame();
                            }
                        }
                        else
                        {
                            if (Field[x - 1, y].isSnake)
                            {
                                StopGame();
                            }
                            else if (Field[x - 1, y].isFood)
                                AddSnakeCell(x - 1, y, false, true);
                            else
                                AddSnakeCell(x - 1, y, true, false);

                        }

                        break;
                    }
                case "RIGHT":
                    {
                        if (x == MaxX)
                        {
                            if (god)
                            {
                                if (Field[0, y].isFood)
                                    AddSnakeCell(0, y, false, true);
                                else
                                    AddSnakeCell(0, y, true, false);
                            }
                            else
                            {
                                StopGame();
                            }
                        }
                        else
                        {
                            if (Field[x + 1, y].isSnake)
                            {
                                StopGame();
                            }
                            else if (Field[x + 1, y].isFood)
                                AddSnakeCell(x + 1, y, false, true);
                            else
                                AddSnakeCell(x + 1, y, true, false);

                        } 

                        break;
                    }

            }

            iTemp += 1;
        }
        public void NewSnakeSet()
        {
            if (MySnake != null)
            {
                MySnake.Clear();
            }
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    Field[i, j].Reset();
                }
            }
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

            #region DIMENTIONS INITIALIZE
            //============================================================



            //==========================================================*/
            #endregion

            #region CONSOLE INITIALIZE
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
            lbSnakeLength.Text = MySnake.Count.ToString();
        }
        void ShowCMD()
        {
            tbConsoleFull.Text += "\n\rCommands:" +
                "god 1\n\r" +
                "god 0\n\r" +
                "start\n\r" +
                "help\n\r";
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tbConsole.Text != null)
            {
                command = tbConsole.Text;
                tbConsole.Text = null;
                tbConsoleFull.Text += command + "\r\n";
                switch (command)
                {
                    case "god 1":
                        {
                            god = true;
                            break;
                        }
                    case "god 0":
                        {
                            god = false;
                            break;
                        }
                    case "start":
                        {
                            StartNewGame();
                            break;
                        }
                    case "help":
                        {
                            ShowCMD();
                            break;
                        }
                    default:
                        {
                            tbConsoleFull.Text += "Неизвестная комманда, help Вам в помощь\n\r";
                            break;
                        }
                }
            }
        }
    }
}