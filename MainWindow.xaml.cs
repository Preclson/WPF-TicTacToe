using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private char turn = 'x';
        private List<List<char>> board = new List<List<char>>();
        private List<char> temp = new List<char>();


        public MainWindow()
        {
            InitializeComponent();
            for(int i = 0; i < 3; i++)
            {
                temp.Clear();
                

                temp.Add(' ');
                temp.Add(' ');
                temp.Add(' ');
                board.Add(temp);
            }            

            foreach(List<char> x in board)
            {
                foreach(char j in x)
                {
                    Console.WriteLine(" [{0}] ", j);
                }
            }
        }


        private void CheckIfWin(char player)
        {
            //rows
            if (board[0][0] == player &&  board[0][1] == player && board[0][2] == player)
            {
                MessageBox.Show("Win");
                Win(board[0][0]);
            }

            if (board[1][0] == player && board[1][1] == player && board[1][2] == player)
            {
                Win(board[1][0]);
            }
            if (board[2][0] == player && board[2][1] == player && board[2][2] == player)
            {
                Win(board[2][0]);
            }

            //columns
            if (board[0][0] == player && board[1][0] == player && board[2][0] == player)
            {
                Win(board[0][0]);
            }

            if (board[0][1] == player && board[1][1] == player && board[2][1] == player)
            {
                Win(board[0][1]);
            }

            if (board[0][2] == player && board[1][2] == player && board[2][2] == player)
            {
                Win(board[0][2]);
            }

            //diagonals
            if (board[0][0] == player && board[1][1] == player && board[2][2] == player)
            {
                Win(board[0][0]);
            }

            if (board[0][2] == player && board[1][1] == player && board[3][0] == player)
            {
                Win(board[0][2]);
            }
        }


        private void Win(char winner)
        {
            MessageBox.Show("And the winner is! " + Char.ToUpper(winner));
        }
        

        private void TextBlock_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBlock textblock = sender as TextBlock;
            char player = turn;

            switch (textblock.Name)
            {
                case "TextBlock00":

                    board[0][0] = turn;
                    break;

                case "TextBlock01":

                    board[0][1] = turn;
                    break;

                case "TextBlock02":

                    board[0][2] = turn;
                    break;

                case "TextBlock10":

                    board[1][0] = turn;
                    break;

                case "TextBlock11":

                    board[1][1] = turn;
                    break;
                case "TextBlock12":

                    board[1][2] = turn;
                    break;

                case "TextBlock20":

                    board[2][0] = turn;
                    break;

                case "TextBlock21":

                    board[2][1] = turn;
                    break;

                case "TextBlock22":

                    board[2][2] = turn;
                    break;
            }


            CheckIfWin(player);


            switch (turn)
            {
                // 'O'
                case 'o':

                    textblock.Text = "O";
                    textblock.VerticalAlignment = VerticalAlignment.Center;
                    textblock.HorizontalAlignment = HorizontalAlignment.Center;
                    TextBlock_FirstPlayer.Visibility = Visibility.Visible;
                    TextBlock_SecondPlayer.Visibility = Visibility.Collapsed;
                    turn = 'x';

                    break;

                /// 'X'
                case 'x':

                    textblock.Text = "X";
                    textblock.VerticalAlignment = VerticalAlignment.Center;
                    textblock.HorizontalAlignment = HorizontalAlignment.Center;
                    TextBlock_FirstPlayer.Visibility = Visibility.Collapsed;
                    TextBlock_SecondPlayer.Visibility = Visibility.Visible;
                    turn = 'o';

                    break;
            }
        }
    }
}
