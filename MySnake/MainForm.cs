//           ����� �����           //
//           ������ �����            //

using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
namespace MySnake
{
    public partial class MainForm : Form
    {
        #region VARIABLES

        //����
        int DimX = 10;
        int DimY = 10;
        //������� ���������
        int SizeX = 30;
        int SizeY = 30;
        int LocationX = 10;
        int LocationY = 50;
        int Margin = 1;
        //������ �������� ����
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
        bool cheats = false;
        bool showsl = false;
        //Command
        string command;
        string username = "Local Player";
        bool enteringName = false;
        //Snake length

        //Pos Command
        int speed = 1;
        //XML
        const string filePath = "records.xml";
        int currentUserRecord = 0;

        #endregion
        public MainForm()
        {
            InitializeComponent();
            Initialize();
            timer1.Interval = TaskDelay;
            tbConsoleFull.Text = "C# Started\r\nReady to play\r\nHost: local\n\r";
            timer2.Start();
        }
        public void StartNewGame()
        {
            NewSnakeSet();
            timer1.Start();
        }
        public void StopGame()
        {
            timer1.Stop();
            MessageBox.Show("��������", "���������");
            //
            int LengthSnake = MySnake.Count;
            if (LengthSnake > currentUserRecord) 
            {
                SaveToXMLFile(LengthSnake);
                tbConsoleFull.Text += $"new record = {LengthSnake}\r\n";
            }
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
            /*
            if (e.KeyCode == Keys.Down)
            {
                Direction = "DOWN";
            }
            */
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

            //lbShowLengthSpeed.Text = MySnake.Count.ToString();
        }
        void ShowCMD()
        {
            tbConsoleFull.Text += "\r\nCommands:\r\n" +
                "god 1\r\n" +
                "god 0\r\n" +
                "start\r\n" +
                "sn_cheats 1\r\n" +
                "sn_cheats 0\r\n" +
                "sn_showsl 1\r\n" +
                "sn_showsl 0\r\n" +
                "cns_clear\r\n" +
                "help\r\n";
        }
        void ShowPos(int truefalse)
        {
            tbConsoleFull.Text += $"sn_showsl == {truefalse}, def == 0\r\n";
        }
        void Cheats(int truefalse)
        {
            tbConsoleFull.Text += $"sn_cheats == {truefalse}, def == 0\r\n";
        }
        void God(int truefalse)
        {
            tbConsoleFull.Text += $"god == {truefalse}, def == 0\r\n";
        }
        void SaveToXMLFile(int SnakeLength)
        {
            XDocument doc = new XDocument();
            XElement records = new XElement("records");
            {
                XElement user = new XElement("user");
                XElement name = new XElement("name", username);
                XElement snakelength = new XElement("snakelength", SnakeLength);
                user.Add(name);
                user.Add(snakelength);
                records.Add(user);
            }
            doc.Add(records);
            doc.Save(filePath);
        }
        string LoadFromXMLFile()
        {
            string result = "";
            XDocument doc = XDocument.Load(filePath);
            XElement? records = doc.Element("records");

            foreach (XElement user in records.Elements("user"))
            {
                XElement? name = user.Element("name");
                XElement? snakelength = user.Element("snakelength");
                result += name.Value + " " + snakelength.Value + "\n";
            }
            return result;
        }
        int SearchUserRecord()
        {
            int result = 0;
            XDocument doc = XDocument.Load(filePath);
            XElement? records = doc.Element("records");

            foreach (XElement user in records.Elements("user"))
            {
                XElement? name = user.Element("name");
                XElement? snakelength = user.Element("snakelength");
                if (name.Value == username)
                {
                    result = int.Parse(snakelength.Value);
                }
            }
            return result;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tbConsole.Text != null)
            {
                command = tbConsole.Text;
                tbConsole.Text = null;
                tbConsoleFull.Text += $"{username}: {command}\r\n";
                switch (command)
                {
                    case "name":
                        {
                            tbConsoleFull.Text += "Enter your name\r\n";
                            enteringName = true;
                            break;
                        }
                    case "sn_cheats 1":
                        {
                            cheats = true;
                            break;
                        }
                    case "sn_cheats 0":
                        {
                            cheats = false;
                            break;
                        }
                    case "sn_cheats":
                        {
                            switch (cheats)
                            {
                                case true:
                                    {
                                        Cheats(1);
                                        break;
                                    }
                                default:
                                    {
                                        Cheats(0);
                                        break;
                                    }
                            }
                            break;
                        }
                    case "god 1":
                        {
                            if (cheats)
                            {
                                god = true;
                                tbConsoleFull.Text += "GODMODE ON\r\n";
                            }
                            else
                            {
                                tbConsoleFull.Text += "No use god command because sn_cheats not equals 1\r\n";
                            }
                            break;
                        }
                    case "god 0":
                        {
                            if (cheats)
                            {
                                god = false;
                                tbConsoleFull.Text += "GODMODE OFF\r\n";
                            }
                            else
                            {
                                tbConsoleFull.Text += "No use god command because sn_cheats not equals 1\r\n";
                            }
                            break;
                        }
                    case "god":
                        {
                            switch (god)
                            {
                                case true:
                                    {
                                        God(1);
                                        break;
                                    }
                                default:
                                    {
                                        God(0);
                                        break;
                                    }
                            }
                            break;
                        }
                    case "start":
                        {

                            StartNewGame();
                            Direction = "UP";
                            break;
                        }
                    case "help":
                        {
                            ShowCMD();
                            break;
                        }
                    case "sn_showsl 1":
                        {
                            //lbShowLengthSpeed.Visible = false;
                            lbShowLengthSpeed.Visible = true;
                            break;
                        }
                    case "sn_showsl 0":
                        {
                            lbShowLengthSpeed.Visible = false;
                            break;
                        }
                    case "graphs 1":
                        {
                            //lbShowLengthSpeed.Visible = false;
                            lbShowLengthSpeed.Visible = true;
                            break;
                        }
                    case "graphs 0":
                        {
                            lbShowLengthSpeed.Visible = false;
                            break;
                        }
                    case "cns_clear":
                        {
                            tbConsoleFull.Clear();
                            break;
                        }
                    case "sn_showsl":
                        {
                            switch (showsl)
                            {
                                case true:
                                    {
                                        ShowPos(1);
                                        break;
                                    }
                                default:
                                    {
                                        ShowPos(0);
                                        break;
                                    }
                            }
                            break;
                        }
                    default:
                        {
                            if (enteringName)
                            {
                                UserLogin();
                            }
                            else
                            {
                                tbConsoleFull.Text += "����������� ��������, help ��� � ������\r\n";
                            }
                            break;
                        }
                }
            }
        }
        void UserLogin()
        {
            username = command;
            enteringName = false;
            tbConsoleFull.Text += $"\r\n����� ���������� {username}\r\n";
            if (SearchUserRecord() != 0)
                tbConsoleFull.Text += $"��� ������� ������ = {SearchUserRecord()}";
            else
                tbConsoleFull.Text += $"��� ������� ������ = null";
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            int count = 0;
            if (timer1.Enabled)
            {
                x = MySnake[0].X;
                y = MySnake[0].Y;
                count = MySnake.Count;
            }
                lbShowLengthSpeed.Text =                $"username = {username}\n" +
                                                        $"Snake Length = {count}\n" +
                                                        $"Snake Speed = {speed} grid/s\n" +
                                                        $"Snake Location = (X = {x}, Y = {y})\n" +
                                                        $"sn_cheats = {cheats}\n" +
                                                        $"godmod = {god}";
            
        }
    }
}