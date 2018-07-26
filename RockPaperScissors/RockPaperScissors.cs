using System;

namespace RockPaperScissors
{
    class Program
    {
        public static void Main()
        {
            bool play = true;
            Random rand = new Random();
            int playerScore = 0;
            int computerScore = 0;
            string playerHand = System.String.Empty;
            string compHand = System.String.Empty;
            string[] compOptions = { "rock", "paper", "scissors" };
            // Main game loop, continues until the getContinue function returns a false
            do
            {
                playerHand = getHand(compOptions);
                compHand = compOptions[rand.Next(0,3)];
                Console.WriteLine(compHand);
                Console.WriteLine(CompareHands(playerHand, compHand, ref playerScore, ref computerScore));
                Console.WriteLine("Player score: {0} Computers score: {1}", playerScore, computerScore);
                play = getContinue();
            } while (play == true);
        }

        // Function to compare the players hand to the computers hand
        // The overloads are as follows
        // string pHand is the passed in player chosen hand
        // string cHand is the computer randomly generated hand
        // ref int pS is the reference variable from main's playerScore variable
        // ref int cS is the reference variable from main's computerScore variable
        // if the hands are the same the function will return a string of its a tie
        // if the player matchs a win condition for their hand the function will
        // return YOU WIN and add one to the reference pS int for the mains
        // variable playerScore
        // if there is no tie and no matched win condition for the player then
        // the computer wins. This passes back the computer win string and
        // add one to the reference cS int. 
        public static string CompareHands(string pHand, string cHand, ref int pS, ref int cS)
        {
            if (pHand == cHand)
            {
                return "It's a tie!!!!";
            }
            else if (pHand == "rock" && cHand == "scissors")
            {
                pS += 1;
                return "YOU WIN!!!!";
            }
            else if (pHand == "scissors" && cHand == "paper")
            {
                pS += 1;
                return "YOU WIN!!!!";
            }
            else if (pHand == "paper" && cHand == "rock")
            {
                pS += 1;
                return "YOU WIN!!!!";
            }
            else
            {
                cS += 1;
                return "You lose, better luck next time";
            }
            // Your code here
        }
        
        // Function to get users rock, paper, or scissor input
        // calls the function recursively until a valid input is 
        // entered
        public static string getHand(string[] compOptions)
        {
            Console.WriteLine("Please enter Rock, Paper, or Scissors:");
            string playerHand = Console.ReadLine().ToLower();
            for( int i = 0; i < compOptions.Length; i++)
            {
                if (playerHand == compOptions[i])
                {
                    return playerHand;
                }   
            }
            return getHand(compOptions);
        }
        
        // Function to get the users input for another round.
        // Return of true keeps the play boolean true.
        // Returning fale will change the play boolean to false.
        public static bool getContinue()
        {
            Console.WriteLine("Would you like to play again?!?!?!  [y/n]");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {   
                return false;
            }
            return getContinue();
        }
    }
}