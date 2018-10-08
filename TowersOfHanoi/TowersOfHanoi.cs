using System;
using System.Collections.Generic;

namespace TowersOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            int numBlocks;
            do
            {
                try
                {
                    numBlocks = getNumMoves();
                    break;
                }
                catch
                {
                    Console.WriteLine("Please enter a whole number."); 
                }
            } while (true);
            Game game = new Game(numBlocks);
            do
            {
                game.movePiece();
            } while(!game.checkWin());
        }
        // function to get the users input for how many blocks they would like to play with.
        // throws an exception if the users input is not an int
        public static int getNumMoves()
        {
            int numBlocks;
            Console.Write("Please enter the number of blocks you would like to play with: ");
            if (Int32.TryParse(Console.ReadLine(),out numBlocks))
            {
                return numBlocks;
            }
            else
            {
                throw new Exception("User did not enter an integer");
            }
        }
    }
    
    class Game
    {
        Dictionary<string, Tower> towers = new Dictionary<string, Tower>();
        // Game constructor takes in the number of blocks the user entered and
        // creates the game with the number of blocks placed in Tower A stack
        public Game(int numBlocks)
        {
            towers["A"] = new Tower();
            towers["B"] = new Tower();
            towers["C"] = new Tower();
            
            for(int i = numBlocks; i > 0; i--)
            {
                Block newB = new Block(i);
                towers["A"].blockStack.Push(newB);
            }
            displayBoard();
        }
        public void displayBoard()
        {
            foreach(string towerName in towers.Keys)
            {
                Console.Write(towerName+":");
                Console.Write(displayBlocks(towerName));
                Console.WriteLine();
            }
        }
        // this method takes the tower key that was passed in from the
        // towers Dictionary and pushes them into a temp stack so that
        // they can be printed in the format of the game.
        public string displayBlocks(string towerName)
        {
            Stack<Block> display = new Stack<Block>();
            foreach(Block block in towers[towerName].blockStack)
            {
                display.Push(block);
            }
            foreach(Block block in display)
            {
                Console.Write(block.weight);
            }
            return "";
        }
        // method check for if the tower the block is being moved to is empty or
        // if the block being moved is smaller than the top block on that tower.
        public bool isLegal(Tower popOff, Tower pushOn)
        {
            if (pushOn.blockStack.Count == 0)
            {
                Console.WriteLine("Can Move");
                return true;
            }
            else if (popOff.blockStack.Peek().weight < pushOn.blockStack.Peek().weight)
            {
                Console.WriteLine("Can move on top");
                return true;
            }
            return false;
        }
        // This method takes in user inputs and stores them in the towerStart and towerEnd strings
        // it them takes those inputs and passes them to the isLegal method to test the move 
        public void movePiece()
        {
            string towerStart = System.String.Empty;
            string towerEnd = System.String.Empty;
            do
            {
                try
                {
                    getMove(ref towerStart, ref towerEnd);
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid tower for either move from, or move to.");
                }
            } while(true);
            if(isLegal(towers[towerStart], towers[towerEnd]))
            {
                towers[towerEnd.ToUpper()].blockStack.Push(towers[towerStart.ToUpper()].blockStack.Pop());
            }
            else
            {
                Console.WriteLine("The move isn't legal.");
            }
            displayBoard();
        }
        // method request the user to input from and to tower. It then
        // checks to see if these entrys are valid. If the values are
        // valid the reference is passed back. Else an exception is returned.
        public void getMove(ref string towerStart,ref string towerEnd)
        {
            string[] inputCheck = {"a", "b", "c"};
            Console.WriteLine("Please enter the tower you would like to move the block from");
            towerStart = Console.ReadLine().ToUpper();
            Console.WriteLine("Please enter the tower you would like to move the block to.");
            towerEnd = Console.ReadLine().ToUpper();
            if (Array.IndexOf(inputCheck,towerStart.ToLower()) < 0 || Array.IndexOf(inputCheck,towerEnd.ToLower()) < 0)
            {
                throw new Exception("Tower entered was not a valid tower.");
            }
        }
        // method to check if the player has won. It simply checks to see if towers A and B
        // are empty. If they are the value returned is true.
        public bool checkWin()
        {
            if (towers["A"].blockStack.Count == 0 && towers["B"].blockStack.Count == 0)
            {
                Console.WriteLine("You WIN!!!");
            }
            return (towers["A"].blockStack.Count == 0 && towers["B"].blockStack.Count == 0);
        }
    }
    // Tower class that holds the stack for each instance of a tower created.
    class Tower
    {
        public Stack<Block> blockStack = new Stack<Block>();
    }
    // Block class that holds the blocks weight for each instance of a Block.
    class Block
    {
        public int weight {get; private set;}
        public Block(int weight)
        {
            this.weight = weight;
        }
    }
}
