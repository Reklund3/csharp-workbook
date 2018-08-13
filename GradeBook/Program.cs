using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace gradeBook2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> students = new Stack<string>();
            Dictionary<string, double[]> gradeBook = new Dictionary<string, double[]>();
            // uncomment below for object implementation
            // List<Student> student = new List<Student>();
            Console.WriteLine("Welcome to the grade book!");
            do
            {
                try
                {
                    students.Push(setStudent(students));
                    if (students.Peek() == "ok")
                    {
                        students.Pop();
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Something went wrong, please try again");
                }
                
            } while (true);
            do
            { 
                Console.Write("Please enter the grades for {0} using a , to seperate them: ", students.Peek());
                gradeBook.Add(students.Pop(), setGrades());
                
                
                
                // Comment in for object implementation
                //student.Add(new Student(students.Pop(), setGrades())) ;
                //Console.Write(student[student.Count-1].stuName+" grades: ");
                //Console.WriteLine(student[student.Count-1].displayGrades());
                //Console.WriteLine(student[student.Count-1].stuName+"'s Average Grade: "+student[student.Count-1].avgGrade);
            } while (students.Count > 0);
            foreach (string student in gradeBook.Keys)
            {   
                double avgGrade = 0;
                Console.WriteLine("{0}'s grades are:", student);
                foreach (double grade in gradeBook[student])
                {
                    Console.Write("{0}, ", grade);
                    avgGrade += grade;
                }
                Console.WriteLine("");
                Console.WriteLine("His average grade: {0}: ", avgGrade/gradeBook[student].Length);
            }
        }
        static string setStudent(Stack<string> students)
        {
            Console.Write("Please enter a students name or \"ok\" to exit");
            string name = Console.ReadLine();
            if(!name.All(Char.IsLetter))
            {
                throw new Exception("names shouldnt contain numbers or special characters");
            }
            else if (name == System.String.Empty)
            {
                throw new Exception("the entry was null");
            }
            else if (students.Contains(name))
            {
                throw new Exception("Student already exists");
            }
            return name;
        }
        static double[] setGrades()
        {
            string gradeInput = Console.ReadLine();
            string[] placeHolder = Regex.Split(gradeInput,",");
            double[] grades = new double[placeHolder.Length];
            string[] errors = new string[placeHolder.Length];
            for (int i = 0; i <= placeHolder.Length-1; i++)
            {
                if (!double.TryParse(placeHolder[i], out grades[i]))
                {
                    errors[i] = placeHolder[i];
                }
            }
            
            return grades;
        }


        // Code to implement project using an Object
        /*
        class Student
        {
            public string stuName {get; private set;}
            public double[] grades {get; private set;}
            public double avgGrade {get; private set;}
            public Student(string stuName, double[] grades)
            {
                this.stuName = stuName;
                this.grades = grades;
                foreach(double element in grades)
                {
                    avgGrade += element;
                }
                avgGrade =avgGrade/grades.Length;
            }
            public string displayGrades()
            {
                foreach(double element in grades)
                {
                    Console.Write(element+", ");
                }
                return "";
            }
        }
        */
    }
}