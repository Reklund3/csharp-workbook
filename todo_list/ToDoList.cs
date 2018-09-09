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
            displayList();
            System.Console.WriteLine("");
            System.Console.WriteLine("Welcome to your ToDo List");
            System.Console.WriteLine("-------- Options --------");
            System.Console.WriteLine("1) Create Task");
            System.Console.WriteLine("2) Read Details");
            System.Console.WriteLine("3) Update Details");
            System.Console.WriteLine("4) Delete Task");
            System.Console.WriteLine("5) Exit To Do Application \n");
            try
            {
                handleOption(getUserOption());
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
            int userNum;
            List<int> inputOptions = new List<int>() {1,2,3,4,5};
            if(Int32.TryParse(Console.ReadLine(),out userNum))
            {
                if(inputOptions.Contains(userNum))
                {
                    return userNum;
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
        void handleOption(int option)
        {
            if (option == 1)
            {
                addTask();
            }
            else if (option == 2)
            {
                //readTask();
            }
            else if (option == 3)
            {
                //updateTask();
            }
            else if (option == 4)
            {
                //deleteTask();
            }
            else if (option == 5)
            {
                System.Console.WriteLine("Exiting program");
                this.runProgram =false;
            }
            else
            {
                throw new Exception("No Option was selected");
            }
        }
        void addTask()
        {
            try
            {
                toDos.Add(new ToDoItem());
            }
            catch
            {
                System.Console.WriteLine("There was a problem adding the task!");
            }
        }
    }
}