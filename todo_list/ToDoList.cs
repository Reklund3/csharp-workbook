using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Sqlite;

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
            catch
            {
                System.Console.WriteLine("That was not a valid ToDo List Option");
            }
        }
        void displayList()
        {
            System.Console.WriteLine("|  I D  |  T a s k  |  D e s c r i p t i o n  |");
            System.Console.WriteLine("|-------|-----------|-------------------------|");
            foreach (ToDoItem item in toDos)
            {
                System.Console.WriteLine("|   {0}   |  {1}  |  {2}             |", item.taskID, item.taskName, item.taskDetail);
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
                deleteTask();
            }
            else if (option == 5)
            {
                System.Console.WriteLine("Exiting program");
                this.runProgram = false;
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
                if (toDos.Count == 0)
                {
                    toDos.Add(new ToDoItem(1));
                }
                else
                {
                    toDos.Add(new ToDoItem(toDos.Count + 1));
                }
            }
            catch
            {
                System.Console.WriteLine("There was a problem adding the task!");
            }
        }
        void readTask()
        {

        }
        void updateTask()
        {

        }
        void deleteTask()
        {
            System.Console.WriteLine("Please enter the task number you would like to delete");
            try
            {
                this.userTaskDelete(Console.ReadLine());
            }
            catch
            {
                System.Console.WriteLine(" That was not a valid task to delete");
            }
        }
        void userTaskDelete(string userInput)
        {
            int userInt;
            if (Int32.TryParse(userInput, out userInt))
            {
                if(toDos.Count >= userInt)
                {
                    this.toDos.RemoveAt(userInt-1);
                }
                else
                {
                    throw new Exception("The number was not in the list");
                }
            }
            else
            {
                throw new Exception("A number was not entered for the item id of the list");
            }
        }
    }
}