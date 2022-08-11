//           Слава Україні           //
//           Героям Слава            //

namespace MySnake
{
    public partial class MainForm : Form
    {
        #region VARIABLES

        //Поле
        int DimX = 30;
        int DimY = 30;
        //Стартові параметри
        int SizeX = 25;
        int SizeY = 25;
        int LocationX = 10;
        int LocationY = 50;
        int GRIGMargin = 2;
        //Масиви ігрового поля
        Grid[,] Field;
        string Direction = "UP";
        List<SnakeCell> MySnake;
        //Round
        bool IsGame = true;
        bool GameOver = false;
        //await\async
        int TaskDelay = 80;

        #endregion
        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }
        public void StartNewGame()
        {
            NewSnakeSet();
        }
        public void StopGame()
        {

        }
        async void SnakeMove() 
        {
            int StartX = DimX / 2;
            int StartY = DimY - 1;
            int iTemp = 2;
            try
            {
                while (true)
                {
                    AddSnakeCell(StartX, StartY - iTemp);
                    iTemp += 1;
                    await Task.Delay(TaskDelay);
                }
            }
            catch
            {
                MessageBox.Show("Вы проиграли");
            }

        }
        public async void NewSnakeSet()
        {
            MySnake = new List<SnakeCell>();
            int StartX = DimX / 2;
            int StartY = DimY - 1;
            await Task.Delay(TaskDelay);
            AddSnakeCell(StartX, StartY);
            await Task.Delay(TaskDelay);
            AddSnakeCell(StartX, StartY - 1);
            await Task.Delay(TaskDelay);
            AddSnakeCell(StartX, StartY - 2);
            SnakeMove();
        }
        public void AddSnakeCell(int x, int y)
        {
            MySnake.Insert(0, new SnakeCell(x, y));
            Field[x, y].SetSnake();
        }
        public void Initialize()
        {
            #region EMPTY
            //============================================================

            //==========================================================*/
            #endregion

            #region SIZE INITIALIZE
            //============================================================

            this.Size = new System.Drawing.Size(DimX * (SizeX + GRIGMargin) + LocationX + 5, DimY * (SizeY + GRIGMargin) + LocationY + 30);

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

            #region SNAKE SET
            //============================================================

            StartNewGame();

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
            int StartX = DimX / 2;
            int StartY = DimY - 1;
            
        }
    }
}