using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SudokuSolver
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] board = {
			{0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0}
		}; 

		
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool isValid(int[,] array, int row, int col, int num)
        {
			for (int i = 0; i < 9; i++)
			{
				if (array[row, i] == num && i != col)
				{
					return false;
				}
				if (array[i, col] == num && i != row)
				{
					return false;
				}
			}
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (array[3 * ((row) / 3) + i, 3 * ((col) / 3) + j] == num)
					{
						return false;
					}
				}
			}
			return true;
		}

		private bool FindNext(int[,] board, int[] rc)
        {
			for(int i = 0; i < 9; i++)
            {
				for(int j = 0; j < 9; j++)
                {
					if(board[i, j] == 0)
                    {
						rc[0] = i;
						rc[1] = j;
						return true;
                    }
                }
            }
			return false;
        }
		
		private bool Solve(int[,] board)
        {
			int[] rc = new int[2];
			if(!FindNext(board, rc))
            {
				return true;
            }
			for(int i = 0; i < 10; i++)
            {
				if(isValid(board, rc[0], rc[1], i))
                {
					board[rc[0], rc[1]] = i;
                    if (Solve(board))
                    {
						return true;
                    }
                    else
                    {
						board[rc[0], rc[1]] = 0;
                    }
                }
            }
			return false;
        }


		public void SolveSudoku_Click(object sender, RoutedEventArgs e)
        {
			UpdateBoard();
			Solve(board);
			UpdateText();
		}
		private void UpdateText()
        {
			_0_0.Text = board[0, 0].ToString();
			_0_1.Text = board[0, 1].ToString();
			_0_2.Text = board[0, 2].ToString();
			_0_3.Text = board[0, 3].ToString();
			_0_4.Text = board[0, 4].ToString();
			_0_5.Text = board[0, 5].ToString();
			_0_6.Text = board[0, 6].ToString();
			_0_7.Text = board[0, 7].ToString();
			_0_8.Text = board[0, 8].ToString();

			_1_0.Text = board[1, 0].ToString();
			_1_1.Text = board[1, 1].ToString();
			_1_2.Text = board[1, 2].ToString();
			_1_3.Text = board[1, 3].ToString();
			_1_4.Text = board[1, 4].ToString();
			_1_5.Text = board[1, 5].ToString();
			_1_6.Text = board[1, 6].ToString();
			_1_7.Text = board[1, 7].ToString();
			_1_8.Text = board[1, 8].ToString();

			_2_0.Text = board[2, 0].ToString();
			_2_1.Text = board[2, 1].ToString();
			_2_2.Text = board[2, 2].ToString();
			_2_3.Text = board[2, 3].ToString();
			_2_4.Text = board[2, 4].ToString();
			_2_5.Text = board[2, 5].ToString();
			_2_6.Text = board[2, 6].ToString();
			_2_7.Text = board[2, 7].ToString();
			_2_8.Text = board[2, 8].ToString();

			_3_0.Text = board[3, 0].ToString();
			_3_1.Text = board[3, 1].ToString();
			_3_2.Text = board[3, 2].ToString();
			_3_3.Text = board[3, 3].ToString();
			_3_4.Text = board[3, 4].ToString();
			_3_5.Text = board[3, 5].ToString();
			_3_6.Text = board[3, 6].ToString();
			_3_7.Text = board[3, 7].ToString();
			_3_8.Text = board[3, 8].ToString();

			_4_0.Text = board[4, 0].ToString();
			_4_1.Text = board[4, 1].ToString();
			_4_2.Text = board[4, 2].ToString();
			_4_3.Text = board[4, 3].ToString();
			_4_4.Text = board[4, 4].ToString();
			_4_5.Text = board[4, 5].ToString();
			_4_6.Text = board[4, 6].ToString();
			_4_7.Text = board[4, 7].ToString();
			_4_8.Text = board[4, 8].ToString();

			_5_0.Text = board[5, 0].ToString();
			_5_1.Text = board[5, 1].ToString();
			_5_2.Text = board[5, 2].ToString();
			_5_3.Text = board[5, 3].ToString();
			_5_4.Text = board[5, 4].ToString();
			_5_5.Text = board[5, 5].ToString();
			_5_6.Text = board[5, 6].ToString();
			_5_7.Text = board[5, 7].ToString();
			_5_8.Text = board[5, 8].ToString();

			_6_0.Text = board[6, 0].ToString();
			_6_1.Text = board[6, 1].ToString();
			_6_2.Text = board[6, 2].ToString();
			_6_3.Text = board[6, 3].ToString();
			_6_4.Text = board[6, 4].ToString();
			_6_5.Text = board[6, 5].ToString();
			_6_6.Text = board[6, 6].ToString();
			_6_7.Text = board[6, 7].ToString();
			_6_8.Text = board[6, 8].ToString();

			_7_0.Text = board[7, 0].ToString();
			_7_1.Text = board[7, 1].ToString();
			_7_2.Text = board[7, 2].ToString();
			_7_3.Text = board[7, 3].ToString();
			_7_4.Text = board[7, 4].ToString();
			_7_5.Text = board[7, 5].ToString();
			_7_6.Text = board[7, 6].ToString();
			_7_7.Text = board[7, 7].ToString();
			_7_8.Text = board[7, 8].ToString();

			_8_0.Text = board[8, 0].ToString();
			_8_1.Text = board[8, 1].ToString();
			_8_2.Text = board[8, 2].ToString();
			_8_3.Text = board[8, 3].ToString();
			_8_4.Text = board[8, 4].ToString();
			_8_5.Text = board[8, 5].ToString();
			_8_6.Text = board[8, 6].ToString();
			_8_7.Text = board[8, 7].ToString();
			_8_8.Text = board[8, 8].ToString();
		}

		private void Test()
        {
			_1_0.Text = board[0, 0].ToString();
			_1_1.Text = board[0, 1].ToString();
			_1_2.Text = board[0, 2].ToString();
			_1_3.Text = board[0, 3].ToString();
			_1_4.Text = board[0, 4].ToString();
			_1_5.Text = board[0, 5].ToString();
			_1_6.Text = board[0, 6].ToString();
			_1_7.Text = board[0, 7].ToString();
			_1_8.Text = board[0, 8].ToString();
		}

		private void UpdateBoard()
        {
			board[0, 0] = Int16.Parse(_0_0.Text);
			board[0, 1] = Int16.Parse(_0_1.Text);
			board[0, 2] = Int16.Parse(_0_2.Text);
			board[0, 3] = Int16.Parse(_0_3.Text);
			board[0, 4] = Int16.Parse(_0_4.Text);
			board[0, 5] = Int16.Parse(_0_5.Text);
			board[0, 6] = Int16.Parse(_0_6.Text); 
			board[0, 7] = Int16.Parse(_0_7.Text);
			board[0, 8] = Int16.Parse(_0_8.Text);


			board[1, 0] = Int16.Parse(_1_0.Text);
			board[1, 1] = Int16.Parse(_1_1.Text);
			board[1, 2] = Int16.Parse(_1_2.Text);
			board[1, 3] = Int16.Parse(_1_3.Text);
			board[1, 4] = Int16.Parse(_1_4.Text);
			board[1, 5] = Int16.Parse(_1_5.Text);
			board[1, 6] = Int16.Parse(_1_6.Text);
			board[1, 7] = Int16.Parse(_1_7.Text);
			board[1, 8] = Int16.Parse(_1_8.Text);


			board[2, 0] = Int16.Parse(_2_0.Text);
			board[2, 1] = Int16.Parse(_2_1.Text);
			board[2, 2] = Int16.Parse(_2_2.Text);
			board[2, 3] = Int16.Parse(_2_3.Text);
			board[2, 4] = Int16.Parse(_2_4.Text);
			board[2, 5] = Int16.Parse(_2_5.Text);
			board[2, 6] = Int16.Parse(_2_6.Text);
			board[2, 7] = Int16.Parse(_2_7.Text);
			board[2, 8] = Int16.Parse(_2_8.Text);


			board[3, 0] = Int16.Parse(_3_0.Text);
			board[3, 1] = Int16.Parse(_3_1.Text);
			board[3, 2] = Int16.Parse(_3_2.Text);
			board[3, 3] = Int16.Parse(_3_3.Text);
			board[3, 4] = Int16.Parse(_3_4.Text);
			board[3, 5] = Int16.Parse(_3_5.Text);
			board[3, 6] = Int16.Parse(_3_6.Text);
			board[3, 7] = Int16.Parse(_3_7.Text);
			board[3, 8] = Int16.Parse(_3_8.Text);


			board[4, 0] = Int16.Parse(_4_0.Text);
			board[4, 1] = Int16.Parse(_4_1.Text);
			board[4, 2] = Int16.Parse(_4_2.Text);
			board[4, 3] = Int16.Parse(_4_3.Text);
			board[4, 4] = Int16.Parse(_4_4.Text);
			board[4, 5] = Int16.Parse(_4_5.Text);
			board[4, 6] = Int16.Parse(_4_6.Text);
			board[4, 7] = Int16.Parse(_4_7.Text);
			board[4, 8] = Int16.Parse(_4_8.Text);


			board[5, 0] = Int16.Parse(_5_0.Text);
			board[5, 1] = Int16.Parse(_5_1.Text);
			board[5, 2] = Int16.Parse(_5_2.Text);
			board[5, 3] = Int16.Parse(_5_3.Text);
			board[5, 4] = Int16.Parse(_5_4.Text);
			board[5, 5] = Int16.Parse(_5_5.Text);
			board[5, 6] = Int16.Parse(_5_6.Text);
			board[5, 7] = Int16.Parse(_5_7.Text);
			board[5, 8] = Int16.Parse(_5_8.Text);
		

			board[6, 0] = Int16.Parse(_6_0.Text);
			board[6, 1] = Int16.Parse(_6_1.Text);
			board[6, 2] = Int16.Parse(_6_2.Text);
			board[6, 3] = Int16.Parse(_6_3.Text);
			board[6, 4] = Int16.Parse(_6_4.Text);
			board[6, 5] = Int16.Parse(_6_5.Text);
			board[6, 6] = Int16.Parse(_6_6.Text);
			board[6, 7] = Int16.Parse(_6_7.Text);
			board[6, 8] = Int16.Parse(_6_8.Text);

			board[7, 0] = Int16.Parse(_7_0.Text);
			board[7, 1] = Int16.Parse(_7_1.Text);
			board[7, 2] = Int16.Parse(_7_2.Text);
			board[7, 3] = Int16.Parse(_7_3.Text);
			board[7, 4] = Int16.Parse(_7_4.Text);
			board[7, 5] = Int16.Parse(_7_5.Text);
			board[7, 6] = Int16.Parse(_7_6.Text);
			board[7, 7] = Int16.Parse(_7_7.Text);
			board[7, 8] = Int16.Parse(_7_8.Text);

			board[8, 0] = Int16.Parse(_8_0.Text);
			board[8, 1] = Int16.Parse(_8_1.Text);
			board[8, 2] = Int16.Parse(_8_2.Text);
			board[8, 3] = Int16.Parse(_8_3.Text);
			board[8, 4] = Int16.Parse(_8_4.Text);
			board[8, 5] = Int16.Parse(_8_5.Text);
			board[8, 6] = Int16.Parse(_8_6.Text);
			board[8, 7] = Int16.Parse(_8_7.Text);
			board[8, 8] = Int16.Parse(_8_8.Text);


		}
    }
}
