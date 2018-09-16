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
                userOptionsMainMenu();
            } while(runProgram);
        }
        public void userOptionsMainMenu()
        {
            //Console.Clear();
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
                handleMainMenuOption(getUserOption(5));
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
            int taskNameLength = 0;
            int taskDetailLength = 0;
            foreach (ToDoItem item in results)
            {
                if (item.taskName.Length > taskNameLength)
                {
                    taskNameLength = item.taskName.Length;
                }
                if (item.taskDetail.Length > taskDetailLength)
                {
                    taskDetailLength = item.taskDetail.Length;
                }
            }
            Console.Clear();
            System.Console.Write("|  I D  |");
            for (int i = 0; i < (taskNameLength/2)-1; i++)
            {
                System.Console.Write(" ");
            }
            System.Console.Write("T A S K");
            for (int i = 0; i < (taskNameLength/2)-1; i++)
            {
                System.Console.Write(" ");
            }
            System.Console.Write("|");
            for (int i = 0; i < (taskDetailLength/2)-1; i++)
            {
                System.Console.Write(" ");
            }
            System.Console.Write("D e t a i l s");
            for (int i = 0; i < (taskDetailLength/2)-1; i++)
            {
                System.Console.Write(" ");
            }
            System.Console.WriteLine("|");

            System.Console.Write("|-------|");
            
            for (int i = 0; i < (taskNameLength/2)-1; i++)
            {
                System.Console.Write("-");
            }
            System.Console.Write("------");
            for (int i = 0; i < (taskNameLength/2); i++)
            {
                System.Console.Write("-");
            }
            System.Console.Write("|");
            for (int i = 0; i < (taskDetailLength/2); i++)
            {
                System.Console.Write("-");
            }
            System.Console.Write("-------------");
            for (int i = 0; i < (taskDetailLength/2)-1; i++)
            {
                System.Console.Write("-");
            }
            System.Console.WriteLine("|");
            
            foreach (ToDoItem item in results)
            {
                System.Console.WriteLine("|   {0}   |  {1}  |  {2}             |", item.Id, item.taskName, item.taskDetail );
            }
        }
        void displayList(ToDoItem singleItem)
        {
            Console.Clear();
            System.Console.WriteLine("|  I D  |  T a s k  |  D e s c r i p t i o n  |");
            System.Console.WriteLine("|-------|-----------|-------------------------|");
            System.Console.WriteLine("|   {0}   |  {1}  |  {2}             |", singleItem.Id, singleItem.taskName, singleItem.taskDetail );
        }
        int getUserOption(int numberOfPasses)
        {
            int userNum;
            List<int> inputOptions = new List<int>();
            for (int i = 1; i <= numberOfPasses; i++)
            {
                inputOptions.Add(i);
            }
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
        void handleMainMenuOption(int option)
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
                updateTask();
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
            try
            {
                int userNum;
                ToDoItem updateItem;
                System.Console.WriteLine("What task number would you like to update");
                if(Int32.TryParse(Console.ReadLine(),out userNum))
                {
                    updateItem = toDoContext.to_do_item.Find(userNum);
                    toDoContext.to_do_item.Update(updateItem);
                    updateItem = handleTaskUpdate(updateItem);
                }
                toDoContext.SaveChanges();
            }
            catch
            {
                System.Console.WriteLine("This was not a valid record to update. Please try again");
            }
        }
        void deleteTask()
        {
            System.Console.WriteLine(" Please enter the task number you would like to delete. ");
            try
            {
                userTaskDelete(Console.ReadLine());
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
        ToDoItem handleTaskUpdate(ToDoItem updateTask)
        {
            System.Console.WriteLine("");
            displayList(updateTask);
            System.Console.WriteLine("");
            System.Console.WriteLine("Would you like to change the Task Name \"Y\" or \"n\"?");
            if (yesNoInput(Console.ReadLine()))
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("Please enter the new Task Name");
                string newName = Console.ReadLine();
                if (newName.Length <= 30 )
                {
                    updateTask.taskName = newName;
                }
                else
                {
                    throw new Exception("The new name was longer than 30 characters and exceed the database column length.");
                }
            }
            System.Console.WriteLine("Would you like to change the Task Detail, \"Y\" or \"n\"?");
            if (yesNoInput(Console.ReadLine()))
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("Please enter the new Task Details");
                string newDetail = Console.ReadLine();
                if (newDetail.Length <= 255 )
                {
                    updateTask.taskDetail = newDetail;
                }
                else
                {
                    throw new Exception("The new name was longer than 255 characters and exceed the database column length.");
                }
            }
            // System.Console.WriteLine("Would you like to change the Task Due Date \"Y\" or \"n\"?");
            // if (yesNoInput(Console.ReadLine()))
            // {
            //     System.Console.WriteLine("");
            //     System.Console.WriteLine("Please enter the new task name");
            //     string newName = Console.ReadLine();
            //     if (newName.Length <= 30 )
            //     {
            //         updateTask.taskName = newName;
            //     }
            //     else
            //     {
            //         throw new Exception("The new name was longer than 30 characters and exceed the database column length.");
            //     }
            // }
            return updateTask;
        }
        ToDoItem getItemById(int taskId)
        {
            return toDoContext.to_do_item.Find(taskId);
        }
        bool yesNoInput(string userInput)
        {
            if (userInput.ToUpper() == "Y")
            {
                return true;
            }
            else if (userInput.ToUpper() == "N")
            {
                return false;
            }
            else
            {
                throw new Exception("The user didnt enter \"Y\" or \"n\" when updating the task item.");
            }
        }
    }
}