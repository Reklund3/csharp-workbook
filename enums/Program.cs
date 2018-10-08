using System;

namespace enums
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your birth date as mm/dd/yyyy ");
            string birthday = Console.ReadLine();
            Console.Write("What Year would you like to find out what day of the week your birthday will fall? ");
            string futureYear = Console.ReadLine();
            DateTime birthdayDate = new DateTime();
            birthdayDate = DateTime.Parse(birthday);
            Console.WriteLine("You were born on a {0}, and your birthday will fall on a {1} in the year {2}.",
                birthdayDate.DayOfWeek,birthdayDate.AddYears(Int32.Parse(futureYear)-birthdayDate.Year).DayOfWeek ,futureYear);
        }
    }
}
