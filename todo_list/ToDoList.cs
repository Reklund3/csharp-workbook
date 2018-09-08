using System;
using System.Collections.Generic;

namespace todo_list
{
    class ToDoList
    {
        List<ToDoItem> toDos;
        bool runProgram = true;
        public ToDoList()
        {
            toDos = new List<ToDoItem>();
            do
            {
                userOptions();
            } while(runProgram);
        }
        public void userOptions()
        {
            Console.Clear();
            System.Console.WriteLine("Welcome to your ToDo List");
            System.Console.WriteLine("-------- Options --------");
            System.Console.WriteLine("1) Create Task");
            System.Console.WriteLine("2) Read Details");
            System.Console.WriteLine("3) Update Details");
            System.Console.WriteLine("4) Delete Task\n");
            displayList();
            System.Console.WriteLine("");
            try
            {
                getUserOption();
            }
            catch (Exception)
            {
                System.Console.WriteLine("That was not a valid ToDo List Option");
            }
        }
        void displayList()
        {
            System.Console.WriteLine("  T a s k  ");
            System.Console.WriteLine("-----------");
            foreach (ToDoItem item in toDos)
            {
                System.Console.WriteLine(item.taskName);
            }
        }
        int getUserOption()
        {
            int[] options = {1,2,3,4};
            int userOption;
            if(Int32.TryParse(Console.ReadLine(),out userOption))
            {
                if(options.Contains(userOption))
                {
                    return userOption;
                }
                else
                {
                    throw new Exception("The entry was not in the option range.");
                }
            }
            else
            {
                throw new Exception("The entry was not a valid number.");
            }
        }
    }
}