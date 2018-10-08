using System;
using System.Collections.Generic;
using System.Linq;


namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
		
            students.Add(new Student("Chris", "123-456-7891", "123 Delany", -2990));
            students.Add(new Student("Kevin", "512-222-2222", "435 Carolyn", -2500));
            students.Add(new Student("Victoria", "512-827-8498", "701 Brazos St", 0));
            students.Add(new Student("Luke", "555-555-5555", "451 Brody Ln", -500));
            
            //your code here
            var results = 
                from stu in students
                where (stu.Balance < 0)
                select stu;
            
            foreach(Student stu in results)
            {
                Console.WriteLine("Student {0} has the following balance {1}. ", stu.Name, stu.Balance);
            }
        }

    }
    public class Student
        {
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int Balance { get; set; }
            
            public Student (string name, string phone, string address, int balance)
            {
                Name = name;
                Phone = phone;
                Address = address;
                Balance = balance;
            }
        }   
}
