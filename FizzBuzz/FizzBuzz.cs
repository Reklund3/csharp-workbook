using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; ++i)
            {
                Console.WriteLine(checkFizzBuzz(i));
            }
        }
        static string checkFizzBuzz(int x)
        {
            if (x % 15 == 0)
            {
                return "FizzBuzz";
            }
            else if (x % 5 == 0)
            {
                return "Buzz";
            }
            else if (x % 3 == 0)
            {
                return "Fizz";
            }
            else
            {
                return x.ToString();
            }
        }
    }
}
