using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace checkpoint1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(divByThree());
            Console.WriteLine("The sum of your numbers is: {0}", sum());
            factorial();
            randomTest();
            findMax();
            Console.ReadKey();
        }
        public static string divByThree()
        {
            int divThreeCount = 0;
            for (int i = 1; i < 100; ++i)
            {
                if (i % 3 == 0)
                {
                    divThreeCount++;
                }
            }
            return String.Format("there are {0} numbers that are divisible by 3 with no remainder between 1 and 100", divThreeCount);
        }
 
        public static decimal sum()
        {
            List<decimal> userNums = new List<decimal> {};
            decimal sum = 0;
            bool test = false;
            do
            {
                userNums.Add(inputCheck(ref test));
            } while(!test);
            foreach (decimal num in userNums)
            {
                sum += num;
            }
            return sum;
        }

        public static decimal inputCheck(ref bool test)
        {
            decimal d = 0.0m;
            string input = System.String.Empty;
            do 
            {
                Console.WriteLine("Please enter a decimal or \"ok\" to stop!");
                input = Console.ReadLine();
                if (input == "ok")
                {
                    test = true;
                    return d;
                }
            } while (!decimal.TryParse(input, out d));
            return d;
        }

        public static void factorial()
        {
            int num = 0;
            int num1 = 0;
            int factorial = 0;
            bool test = false;
            do 
            {
                Console.WriteLine("Please enter a whole number to factor!");
                test = int.TryParse(Console.ReadLine(), out num);
                factorial = num1 = num;
            } while (!test);
            for (int i = 0; i <= num; ++i)
            {
                num--;
                factorial = factorial * num;
            }
            Console.WriteLine("The factorial of {0} is: {1}", num1, factorial);
        }

        public static void randomTest()
        {
            Random num = new Random();
            int rand = num.Next(1,11);
            string input = System.String.Empty;
            int[] playerNum = new int[4];
            for (int i = 0; i < playerNum.Length; i++)
            {
                do 
                {
                    Console.WriteLine("Please enter a number");
                    input = Console.ReadLine();
                    bool test = int.TryParse(input, out playerNum[i]);
                    if (playerNum[i] <= 10 && playerNum[i] >= 1)
                    {
                        break;
                    }
                } while (true);
            }
            Console.WriteLine("Let's see if you win!!");
            for (int i = 0; i < playerNum.Length; i++)
            {
                if (playerNum[i] == rand)
                {
                    Console.WriteLine("YOU WIN!!!");
                    break;
                }
            }
        }

        public static void findMax()
        {
            Console.WriteLine("Please enter numbers seperated by a comma.");
            string[] strArray = Regex.Split(Console.ReadLine(), ",");
            Array.Sort(strArray);
            int holder = 0;
            List<int> nums = new List<int> {};
            for (int i = 0; i < strArray.Length; i++)
            {
                int.TryParse(strArray[i],out holder);
                nums.Add(holder);
            }
            Console.WriteLine("The largest number entered is {0}, the smallest number is {1}", nums[nums.Count-1], nums[0]);
        }
    }
}
