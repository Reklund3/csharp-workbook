using System;

namespace TicTacToe
{
    class Program
    {
        public static string playerTurn = "X";
        public static string[][] board = new string[][]
        {
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "}
        };

        public static void Main()
        {
            do
            {
                DrawBoard();
                GetInput();
                if (CheckForWin())
                {
                    DrawBoard();
                    Console.WriteLine("player {0} won!", playerTurn);
                }
                playerChange();
            } while (!CheckForWin() && !CheckForTie());
            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }

        public static void GetInput()
        {
            Console.WriteLine("Player " + playerTurn);
            Console.WriteLine("Enter Row:");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Column:");
            int column = int.Parse(Console.ReadLine());
            if (board[row][column] == " ")
            {
                PlaceMark(row, column);
            }
            else
            {
                GetInput();
            }
        }
        public static void playerChange()
        {
            if (playerTurn == "X")
            {
                playerTurn = "O";
            }
            else
            {
                playerTurn = "X";
            }
        }
        public static void PlaceMark(int row, int column)
        {
            // your code goes here
            board[row][column] = playerTurn;

        }

        public static bool CheckForWin()
        {
            // your code goes here
            if (HorizontalWin())
            {
                return true;
            }
            else if (VerticalWin())
            {
                return true;
            }
            else if (DiagonalWin())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckForTie()
        {
            // your code goes here

            return false;
        }
        
        public static bool HorizontalWin()
        {
            // your code goes here
            for (int i = 0; i < 3; ++i)
            {
                if (board[i][0] == board[i][1] && board[i][1] == board[i][2])
                {
                    if (board[i][0] == " " || board[i][1] == " " || board[i][2] == " ")
                    {
                        
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool VerticalWin()
        {
            // your code goes here
            for (int i = 0; i < 3; ++i)
            {
                if (board[0][i] == board[1][i] && board[1][i] == board[2][i])
                {
                    if (board[0][i] == " " || board[1][i] == " " || board[2][i] == " ")
                    {
                        
                    }
                    else {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool DiagonalWin()
        {
            // your code goes here
            if (board[0][0] == board[1][1] && board[1][1] == board[2][2])
            {
                if (board[0][0] == " " || board[1][1] == " " || board[2][2] == " ")
                {
                    
                }
                else {
                    return true;
                }
            }
            if (board[0][2] == board[1][1] && board[1][1] == board[2][0])
            {
                if (board[0][2] == " " || board[1][1] == " " || board[2][0] == " ")
                {
                    
                }
                else {
                    return true;
                }
            }
            return false;
        }

        public static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("  0 1 2");
            Console.WriteLine("0 " + String.Join("|", board[0]));
            Console.WriteLine("  -----");
            Console.WriteLine("1 " + String.Join("|", board[1]));
            Console.WriteLine("  -----");
            Console.WriteLine("2 " + String.Join("|", board[2]));
        }
    }
}
