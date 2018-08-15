using System;
using System.Collections.Generic;

namespace Mastermind {
    class Program
    {
        static void Main (string[] args)
        {
            int numTries = 0;
            getTries(ref numTries);
            Game game = new Game (generateRandomCode());
            for (int turns = numTries; turns > 0; turns--) {
                Console.WriteLine($"You have {turns} tries left");
                Console.WriteLine ("Choose four letters: ");
                string letters = Console.ReadLine ();
                Ball[] balls = new Ball[4];
                for (int i = 0; i < 4; i++) {
                    balls[i] = new Ball (letters[i].ToString());
                }
                Row row = new Row (balls);
                game.AddRow (row);
                Console.WriteLine (game.Rows);
            }
            Console.WriteLine ("Out Of Turns");
        }
        public static void getTries(ref int numTries)
        {
            Console.WriteLine("Please enter how many times you would like to try and win. Please enter numbers.");
            if (!Int32.TryParse(Console.ReadLine(), out numTries))
            {
                getTries(ref numTries);
            }
        }
        public static string[] generateRandomCode()
        {
            Random rnd = new Random();
            string[] letters = {"a", "b", "c", "d"};
            string[] solution = new string[4];
            for(var i = 0; i < solution.Length; i++)
            {
                solution[i] = letters[rnd.Next(0, letters.Length)];
            }
            return solution;
        }
    }

    class Ball
    {
        public string Letter {get; private set;}
        public Ball(string letter)
        {
            this.Letter = letter;
        }
    }

    class Row {
        public Ball[] balls = new Ball[4];

        public Row (Ball[] balls)
        {
            this.balls = balls;
        }

        public string Balls
        {
            get
            {
                foreach (var ball in this.balls)
                {
                    Console.Write (ball.Letter);
                }
                return "";
            }
        }
    }
    class Game
    {
        private List<Row> rows = new List<Row> ();
        private string[] answer = new string[4];
        public Game (string[] answer)
        {
            this.answer = answer;
        }
        private string Score (Row row)
        {
            string[] answerClone = (string[]) this.answer.Clone ();
            // red is correct letter and correct position
            // white is correct letters minus red
            // this.answer => ["a", "b", "c", "d"]
            // row.balls => [{ Letter: "c" }, { Letter: "b" }, { Letter: "d" }, { Letter: "a" }]
            int red = 0;
            for (int i = 0; i < 4; i++)
            {
                if (answerClone[i] == row.balls[i].Letter)
                {
                    red++;
                }
            }
            if (red == 4)
            {
                return "YOU WON!!!";
            }
            int white = 0;
            for (int i = 0; i < 4; i++)
            {
                int foundIndex = Array.IndexOf (answerClone, row.balls[i].Letter);
                if (foundIndex > -1)
                {
                    white++;
                    answerClone[foundIndex] = null;
                }
            }
            return $" {red} - {white - red}";
        }

        public void AddRow (Row row)
        {
            this.rows.Add (row);
        }

        public string Rows
        {
            get 
            {
                foreach (var row in this.rows)
                {
                    Console.Write (row.Balls);
                    Console.WriteLine (Score (row));
                }
                return null;
            }
        }
    }

}