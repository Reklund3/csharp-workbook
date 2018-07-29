using System;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;
            int age = 32;
            int numR;
            int ten = 10;
            int oneHundred = 100;
            decimal num = 3.77m;
            char[] firstName = {'R', 'o', 'b', 'e', 'r', 't'};
            string lastName = "Eklund";
            string job = "Financial analyst";
            string favoriteBand = "Imagine Dragons";
            string favoriteSportsTeam = "Dallas Cowboys";
            bool people = true;
            bool f = false;
            Console.WriteLine("Enter the first number");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number");
            y = int.Parse(Console.ReadLine());
            Console.WriteLine("The first number times the second number is " + x*y);
            Console.WriteLine("Enter the number of yards you would like to convert to inches");
            num = decimal.Parse(Console.ReadLine());
            Console.WriteLine(num + " of yards is " + num*36 + " inches");
            numR = Convert.ToInt32(num*num);
            Console.WriteLine("Number 3.77 times multilied by itself is " + num*num 
                + ". This number converted to an int is " + numR);
            Console.WriteLine("The sum of {0} and {1} is " + (oneHundred+ten), oneHundred, ten);
            Console.WriteLine("The product of {0} and {1} is " + (oneHundred*ten), oneHundred, ten);
            Console.WriteLine("The difference between {0} and {1} is " + (oneHundred-ten), oneHundred, ten);
            Console.WriteLine("The Quotient of {0} and {1} is " + (oneHundred/ten), oneHundred, ten);
        }
    }
}