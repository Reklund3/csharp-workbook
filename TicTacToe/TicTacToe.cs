using System;

namespace TicTacToe
{
    class Program
    {
        public static string playerTurn = "X";
        
        // used to keep track of the number of turns taken to determine if a tie condition has been met
        public static int turnNum = 0; 
        
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
                turnNum++;
                if (CheckForWin())
                {
                    DrawBoard();
                    Console.WriteLine("player {0} won!", playerTurn);
                }
                else if (CheckForTie())
                {
                    DrawBoard();
                    Console.WriteLine("It's a tie!! Nobody wins!!! YAY");
                }
                playerChange();
            } while (!CheckForWin() && !CheckForTie());
        }

        public static void GetInput()
        {
            Console.WriteLine("Player " + playerTurn);
            Console.WriteLine("Enter Row:");
            int row = checkInput();
            Console.WriteLine("Enter Column:");
            int column = checkInput();
            if (board[row][column] == " ")
            {
                PlaceMark(row, column);
            }
            else
            {
                GetInput();
            }
        }
        public static int checkInput()
        {
            bool test;
            int num;
            do {
                test = Int32.TryParse(Console.ReadLine(), out num);
                if (num < 0 || num >2)
                {
                    test = false;
                }
            } while (!test);
            return num;
        }
        // Function to change back and forth between players
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
        // Function to player the players input on the board
        public static void PlaceMark(int row, int column)
        {
            // your code goes here
            board[row][column] = playerTurn;

        }
        // Function to check for win conditions, houses the function
        // calls for each type of win Horizontal, Virtical, and Diagonal
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
        // function to check for a tie. If the play count reaches 
        // nine and no player has won then the game is a tie
        public static bool CheckForTie()
        {
            // your code goes here
            if (turnNum == 9)
            {
                return true;
            }
            return false;
        }
        // Function to test horizontal win conditions
        // loops through the array until with a length of 3
        public static bool HorizontalWin()
        {
            // your code goes here
            for (int i = 0; i < 3; ++i)
            {
                if (board[i][0] == board[i][1] && board[i][1] == board[i][2])
                {
                    if (board[i][0] == " ")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        // Function to test virtical win consitions
        // loops through the array until with a length of 3
        public static bool VerticalWin()
        {
            // your code goes here
            for (int i = 0; i < 3; ++i)
            {
                if (board[0][i] == board[1][i] && board[1][i] == board[2][i])
                {
                    if (board[0][i] == " ")
                    {
                        
                    }
                    else {
                        return true;
                    }
                }
            }
            return false;
        }
        // checks the two possible diagonal win conditions
        // if either condition exists the function return is true
        // if neither of the conditions is true then false is returned
        public static bool DiagonalWin()
        {
            // your code goes here
            if (board[0][0] == board[1][1] && board[1][1] == board[2][2])
            {
                if (board[0][0] == " ")
                {
                    return false;
                }
                else {
                    return true;
                }
            }
            if (board[0][2] == board[1][1] && board[1][1] == board[2][0])
            {
                if (board[0][2] == " ")
                {
                    return false;
                }
                else {
                    return true;
                }
            }
            return false;
        }
        // Draws the game board
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
