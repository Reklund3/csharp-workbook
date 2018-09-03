using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            do
            {
                try
                {
                    game.inputCoords();
                    game.movePiece();
                }
                catch (Exception e)
                {
                    // "Invalid move or position, please try again"
                    Console.WriteLine(e);
                }
            } while (!game.CheckForWin());
        }
    }

    public class Checker
    {
        public string Symbol { get; private set; }
        public int[] Position { get; set; }
        // If color is White then its true else if color is Black then its false
        public bool Color { get; private set; }
        public bool kinged { get; private set; }
        // checker constructore that sets the initial variables
        public Checker(bool color, int[] Position)
        {
            // Your code here
            this.Color = color;
            this.Position = Position;
            this.kinged = false;
            // sets the symbol to o or x based on color bool
            if (this.Color == true)
            {
                this.Symbol = "o";
            }
            else
            {
                this.Symbol = "x";
            }
        }
        // member method that is called when a piece
        // meets the conditions to be kinged
        public void kingChecker()
        {
            this.Symbol = this.Symbol.ToUpper();
            this.kinged = true;
        }
    }
    public class Board
    {
        public string[,] Grid { get; set; }
        public List<Checker> Checkers { get; set; }
        // Board constructor creates a new List of Checkers,
        // a new two diminsional string array, and sets each
        // position in the array to blank (two spaces for proper
        // terminal alignment of columns)
        public Board()
        {
            // Your code here
            Checkers = new List<Checker>();
            Grid = new string[8, 8];
            for (int i = 0; i <= 7; i++)
            {
                for (int n = 0; n <= 7; n++)
                {
                    Grid[i, n] = "  ";
                }
            }
        }
        // Generates each sides checkers
        public void GenerateCheckers()
        {
            // initial x & y values for the first for loop
            int x = 0;
            int y = 1;
            // loop to instantiate 12 player o checker pieces.
            for (int i = 0; i < 12; i++)
            {
                Checker checker = new Checker(true, new int[] { x, y });
                Checkers.Add(checker);
                if (y == 7)
                {
                    y = -2;
                    x += 1;
                }
                else if (y == 6)
                {
                    y = -1;
                    x += 1;
                }
                y += 2;
            }
            // change the x & y values for the second for loop
            x = 5;
            y = 0;
            // loop to instantiate 12 player x checker pieces.
            for (int i = 0; i < 12; i++)
            {
                Checker checker = new Checker(false, new int[] { x, y });
                Checkers.Add(checker);
                if (y == 7)
                {
                    y = -2;
                    x += 1;
                }
                else if (y == 6)
                {
                    y = -1;
                    x += 1;
                }
                y += 2;
            }
        }
        // Takes each checker in the List<Checkers> and places
        // that checkers symbol on the Grid array
        public void PlaceCheckers()
        {
            foreach (Checker checker in Checkers)
            {
                Grid[checker.Position[0], checker.Position[1]] = " " + checker.Symbol;
            }
        }
        // places the checkers on the board and then draws the board
        public void DrawBoard()
        {
            PlaceCheckers();
            Console.WriteLine("  0 1 2 3 4 5 6 7");
            for (int i = 0; i <= 7; i++)
            {
                Console.Write(i);
                for (int n = 0; n <= 7; n++)
                {
                    Console.Write(Grid[i, n]);
                }
                Console.WriteLine();
            }
            return;
        }
        // Takes the row and column passed in and returns the checker 
        // object at that position
        public Checker SelectChecker(int row, int column)
        {
            return Checkers.Find(x => x.Position.SequenceEqual(new List<int> { row, column }));
        }
        // Takes a checker, row, and column and does the following
        // 1.) clears the Grid array position that the checker was at
        // 2.) updates the checkers Position Array Attribute with the new row and colum
        // 3.) checks to see if the checker should be crowned
        // 4.) and finally draws the new board
        public void placeChecker(Checker checker, int row, int column)
        {
            Grid[checker.Position[0], checker.Position[1]] = "  ";
            checker.Position = new int[] { row, column };
            if (checker.Symbol == "x" && checker.Position[0] == 0)
            {
                checker.kingChecker();

            }
            else if (checker.Symbol == "o" && checker.Position[0] == 7)
            {
                checker.kingChecker();
            }
            DrawBoard();
        }
        // takes in an row and column, removes the piece from
        // List<Checkers>, and clears the position on the Grid
        public void RemoveChecker(int row, int column)
        {
            // Your code here\
            this.Checkers.Remove(SelectChecker(row, column));
            Grid[row, column] = "  ";
        }
        // Checks to see what piece is still left on the board if there
        // is only one players pieces left
        public bool CheckForWin()
        {
            if (!Checkers.Exists(x => x.Color == true))
            {
                System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                System.Console.WriteLine("~~ Player {0} <= WINS THE GAME!!  ~~", Checkers[0].Symbol);
                System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
            // Color is White for True and Black for false
            return Checkers.All(x => x.Color == true) || !Checkers.Exists(x => x.Color == true);
        }
    }

    class Game
    {
        Board board;
        string playerTurn = "x";
        // Declares the cordinate variables for which
        // user input will be stored
        // fromX = will be the row input from the user
        // fromY = will be the column input from the user
        // toX = will be the destination row entered by user
        // toY = will be the destination column entered by the user
        int fromX, fromY, toX, toY;
        // Game constructor to instantiate a Board
        // generate the checkers and display the board
        public Game()
        {
            this.board = new Board();
            this.board.GenerateCheckers();
            this.board.DrawBoard();
        }
        // prompts the user to enter the desired coordinates
        public void inputCoords()
        {
            Console.Write("Please enter a from row number :");
            this.fromX = userInput();
            Console.Write("Please enter a from column number :");
            this.fromY = userInput();
            Console.Write("Please enter a to row number :");
            this.toX = userInput();
            Console.Write("Please enter a to column number :");
            this.toY = userInput();
        }
        // takes the user input and checks to see if it was a 
        // number and if that number was within the board.
        // if not throws an exception detailing which of the two
        // conditions were not met
        public static int userInput()
        {
            int userEntry;
            if (Int32.TryParse(Console.ReadLine(), out userEntry))
            {
                if (userEntry <= 7 && userEntry >= 0)
                {
                    return userEntry;
                }
                else
                {
                    throw new Exception("Number entered is not on the board");
                }
            }
            else
            {
                throw new Exception("Entry is not a valid position as it isnt a number");
            }
        }
        // movePiece is the primary handler of game activity
        public void movePiece()
        {
            // checks to is if the spot is bank, if it is 
            // an exception is thrown to the user
            if (isSpotBlank(fromX, fromY))
            {
                throw new Exception("The chosen spot was blank");
            }
            // checks to see if the from position piece belongs to the player whos turn it is
            else if (!isPlayerPiece(this.board.SelectChecker(fromX, fromY)))
            {
                throw new Exception("The selected checker doesnt belong to the current players turn");
            }
            // checks to see if the destination poisiton is blank, if the destination blank is not an exception is thrown
            else if (!isSpotBlank(toX, toY))
            {
                throw new Exception("The destination position is occupied");
            }
            // checks to see if the move is forward for that piece, if it is not forward an exception is thrown
            else if (!isForward(this.board.SelectChecker(fromX, fromY)))
            {
                throw new Exception("The move is not forward and thus invalid");
            }
            // checks to see if the player move a piece more that two spots forward, if it is an exception is thrown
            else if (moreThanTwoSpots())
            {
                throw new Exception("The move was more than two spots forward");
            }
            // checks to see if the player move a piece forward one spot
            // if it is then the place checker function is called on the board object
            else if (validMoveOne())
            {
                this.board.placeChecker(this.board.SelectChecker(fromX, fromY), toX, toY);
            }
            // checks to see if the player chose to move two spaces over an enemy.
            // if getEnemy is not null
            // then the removeChecker and placeChecker functions are called
            else if (getEnemy() != null)
            {
                this.board.RemoveChecker(getEnemy().Position[0], getEnemy().Position[1]);
                this.board.placeChecker(this.board.SelectChecker(fromX, fromY), toX, toY);
            }
            // throws an exception of any other unhandled event
            else
            {
                throw new Exception("Unhandled exception from user input");
            }
            // alternates player turns 
            if (playerTurn == "x")
            {
                playerTurn = "o";
            }
            else
            {
                playerTurn = "x";
            }
        }
        // takes in a row and column, if the position is blank it returns true
        bool isSpotBlank(int row, int column)
        {
            if (board.Grid[row, column] == "  ")
            {
                return true;
            }
            return false;
        }
        // takes in a checker object and checks to see if that checkers
        // symbol matchs the current players turn. If it matchs it returns
        // true
        bool isPlayerPiece(Checker checker)
        {
            // the to lower is used for when a piece is kinged
            // the symbol becomes an upper case
            if (playerTurn == checker.Symbol.ToLower())
            {
                return true;
            }
            return false;
        }
        // checks to see if the checkers move was forward
        // if the checker is Kinged then the return is always true
        bool isForward(Checker checker)
        {
            if (checker.kinged)
            {
                return true;
            }
            else if (checker.Symbol == "x" && checker.Position[0] <= toX)
            {
                return false;
            }
            else if (checker.Symbol == "o" && checker.Position[0] >= toX)
            {
                return false;
            }
            return true;
        }
        // checks to see if the move was more than two spots forward
        // if so it returns true
        bool moreThanTwoSpots()
        {
            if (Math.Abs(fromX - toX) > 2)
            {
                return true;
            }
            return false;
        }
        // checks to see if the move was one position from the row
        // and one position on the column
        bool validMoveOne()
        {
            if (Math.Abs(fromX - toX) == 1 && Math.Abs(fromY - toY) == 1)
            {
                return true;
            }
            return false;
        }
        // returns the checker that was captured by the jump
        Checker getEnemy()
        {
            if (playerTurn == "x")
            {
                if (toY < fromY && playerTurn != board.SelectChecker(fromX + ((toX - fromX) / 2), toY + 1).Symbol.ToLower())
                {
                    return board.SelectChecker(fromX + ((toX - fromX) / 2), toY + 1);
                }
                else if (fromY < toY && playerTurn != board.SelectChecker(fromX + ((toX - fromX) / 2), toY - 1).Symbol.ToLower())
                {
                    return board.SelectChecker(fromX + ((toX - fromX) / 2), toY - 1);
                }
            }
            else if (playerTurn == "o")
            {
                if (toY < fromY && playerTurn != board.SelectChecker(fromX + ((toX - fromX) / 2), toY + 1).Symbol.ToLower())
                {
                    return board.SelectChecker(fromX + ((toX - fromX) / 2), toY + 1);
                }
                else if (fromY < toY && playerTurn != board.SelectChecker(fromX + ((toX - fromX) / 2), toY - 1).Symbol.ToLower())
                {
                    return board.SelectChecker(fromX + ((toX - fromX) / 2), toY - 1);
                }
            }
            return null;
        }
        // calls the boards check for win condition and returns that value
        public bool CheckForWin()
        {
            return this.board.CheckForWin();
        }
    }
}