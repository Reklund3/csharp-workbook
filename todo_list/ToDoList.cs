using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace todo_list
{
    public class ToDoList
    {
        List<ToDoItem> toDos;
        bool runProgram = true;
        ToDoListContext toDoContext;
        public ToDoList()
        {
            toDoContext = new ToDoListContext();
            //toDoContext.Database.EnsureDeleted();
            toDoContext.Database.EnsureCreated();
            
            toDos = new List<ToDoItem>();
            do
            {
                userOptions();
            } while(runProgram);
        }
        public void userOptions()
        {
            // Console.Clear();
            System.Console.WriteLine("");
            System.Console.WriteLine("Welcome to your ToDo List");
            System.Console.WriteLine("-------- Options --------");
            System.Console.WriteLine("1) Create Task");
            System.Console.WriteLine("2) Get To Do List");
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
            var results = from item in toDoContext.to_do_item
            select item;
            Console.Clear();
            System.Console.WriteLine("|  I D  |  T a s k  |  D e s c r i p t i o n  |");
            System.Console.WriteLine("|-------|-----------|-------------------------|");
            foreach (ToDoItem item in results)
            {
                System.Console.WriteLine("|   {0}   |  {1}  |  {2}             |", item.Id, item.taskName, item.taskDetail );
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
                readTask();
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
                System.Console.WriteLine(" Exiting program. ");
                this.runProgram = false;
            }
            else
            {
                throw new Exception(" No Option was selected. ");
            }
        }
        void addTask()
        {
            try
            {
                toDoContext.to_do_item.Add(ToDoItem.createTask());
                toDoContext.SaveChanges();
            }
            catch
            {
                System.Console.WriteLine(" There was a problem adding the task! ");
            }
        }
        void readTask()
        {
            displayList();
        }
        void updateTask()
        {

        }
        void deleteTask()
        {
            System.Console.WriteLine(" Please enter the task number you would like to delete. ");
            try
            {
                this.userTaskDelete(Console.ReadLine());
            }
            catch
            {
                System.Console.WriteLine(" That was not a valid task to delete! ");
            }
        }
        void userTaskDelete(string userInput)
        {            
            int userInt;
            if (Int32.TryParse(userInput, out userInt))
            {
                if(toDoContext.to_do_item.Find(userInt) != null)
                {
                    toDoContext.to_do_item.Remove(getItemById(userInt));
                    toDoContext.SaveChanges();
                }
                else
                {
                    throw new Exception(" The number was not in the list. ");
                }
            }
            else
            {
                throw new Exception(" A number was not entered for the item id of the list. ");
            }
        }
        ToDoItem getItemById(int taskId)
        {
            return toDoContext.to_do_item.Find(taskId);
        }
    }
}