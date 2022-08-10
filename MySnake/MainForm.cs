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

        #endregion
        public MainForm()
        {
            InitializeComponent();
            Initialize();
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
    }
}