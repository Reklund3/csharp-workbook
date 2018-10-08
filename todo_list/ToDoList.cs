using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace todo_list
{
    public class ToDoList
    {
        // bool for the program loop, true until user indicates the which to close the program
        bool runProgram = true;
        // entity framework declaration of the database context
        ToDoListContext toDoContext;
        // program entry point and constructor for the To Do List
        public ToDoList()
        {
            // defines the new context list for use within the program
            toDoContext = new ToDoListContext();
            // ensures that hte database is created before entering the actual application functionality
            toDoContext.Database.EnsureCreated();
            // Start of the program loop
            do
            {
                userOptionsMainMenu();
                userOptionEntry();
            } while(runProgram);
        }
        // Displays the primary options list for the user
        public void userOptionsMainMenu()
        {
            System.Console.WriteLine("");
            System.Console.WriteLine("Welcome to your ToDo List");
            System.Console.WriteLine("-------- Options --------");
            System.Console.WriteLine("1) Create Task");
            System.Console.WriteLine("2) Get To Do List");
            System.Console.WriteLine("3) Update Details");
            System.Console.WriteLine("4) Delete Task");
            System.Console.WriteLine("5) Complete / Incomplete Task");
            System.Console.WriteLine("6) Exit To Do Application \n");
            
        }
        // Method that tries to take the users input
        public void userOptionEntry()
        {
            try
            {
                handleMainMenuOption(getUserOption(6));
            }
            catch
            {
                System.Console.WriteLine("That was not a valid ToDo List Option");
            }
        }
        // Determines the largest value in the list and returns the length of that string
        // it is passed a list of ToDoItem's and a bool value, the bool is used to determine which
        // column it is looking at, Name or Detail.
        int fieldLength(List<ToDoItem> list, bool nameOrDetail)
        {
            int len = 0;
            foreach (ToDoItem item in list)
            {
                if (nameOrDetail)
                {
                    if (item.taskName.Length > len)
                    {
                        len = item.taskName.Length;
                    }
                }
                else if (!nameOrDetail)
                {
                    if (item.taskName.Length > len)
                    {
                        len = item.taskDetail.Length;
                    }
                }
            }
            return len;
        }
        // function to return a list of the items pulled from the table.
        // takes in a bool value to determine if the user wants only incomplete task or all tasks
        public List<ToDoItem> queryStatus(bool incomplete)
        {
            var results = from item in toDoContext.to_do_item select item;
            if(incomplete)
            {
                results = from item in toDoContext.to_do_item where (item.taskComplete == false) select item;
                return results.ToList();
            }
            return results.ToList();
        }
        void displayList()
        {
            // list for storing the query results.
            List<ToDoItem> itemsList = new List<ToDoItem>();
            // trys to get the users input to see if they want to list all tasks or incomplete tasks
            try
            {
                System.Console.WriteLine("Would you like to see all incomplete To Do Tasks? If so enter \"Y\" or \"YES\".");
                System.Console.WriteLine("If you would like to see only To Do Tasks that are not complete enter \"N\" or \"NO\".");
                if (yesNoInput(Console.ReadLine()))
                {
                    itemsList = queryStatus(true);
                }
                else
                {
                    itemsList = queryStatus(false);
                }
            }
            catch
            {
                System.Console.WriteLine("The entry was not a valid option returning to menu.");
                System.Console.WriteLine();
            }
            // these variables are to determin the max length of the name and detail variables.
            // this is used to format the column widths
            int taskNameLength = fieldLength(itemsList, true);
            int taskDetailLength = fieldLength(itemsList, false);
            
            //header names loops to center the header names in their respective columns
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
            System.Console.Write("  D E T A I L S  ");
            for (int i = 0; i < (taskDetailLength/2)-1; i++)
            {
                System.Console.Write(" ");
            }
            System.Console.WriteLine("| S T A T U S |");
            //header line break to create the header detail seperators for the table
            System.Console.Write("|-------|");
            for (int i = 0; i < (taskNameLength)+4; i++)
            {
                System.Console.Write("-");
            }
            System.Console.Write("|");
            for (int i = 0; i < (taskDetailLength)+14; i++)
            {
                System.Console.Write("-");
            }
            System.Console.WriteLine("|-------------|");
            
            // display todo items spaced on the max width of the displayed items
            foreach (ToDoItem item in itemsList)
            {
                System.Console.Write("|   {0}   |",item.Id);
                System.Console.Write("  {0}  ",item.taskName);
                for (int i = 0; i < (taskNameLength-item.taskName.Length); i++)
                {
                    System.Console.Write(" ");
                }
                System.Console.Write("|");
                System.Console.Write("  {0}  ",item.taskDetail);
                for (int i = 0; i < (taskDetailLength-item.taskDetail.Length)+10; i++)
                {
                    System.Console.Write(" ");
                }
                System.Console.Write("|");
                System.Console.Write(" {0} ",item.taskComplete == true ? "Done" : "    " );
                for(int i = 0; i < 7; i++)
                {
                    System.Console.Write(" ");
                }
                System.Console.WriteLine("|");
            }
        }
        // displays a single list item.
        void displayList(ToDoItem singleItem)
        {
            Console.Clear();
            System.Console.WriteLine("|  I D  |  T a s k  |  D e s c r i p t i o n  | S T A T U S |");
            System.Console.WriteLine("|-------|-----------|-------------------------|-------------|");
            System.Console.WriteLine("|   {0}   |  {1}  |  {2}                 |    {3}     |", singleItem.Id, singleItem.taskName, singleItem.taskDetail, singleItem.taskComplete == true ? "Done" : "    " );
        }
        // function takes in a user input and determines if that input is in the range of options
        // the int numberOfPasses is used to be pass in the number of options of the calling menu.
        // this was setup for later implementations using submenus
        int getUserOption(int numberOfPasses)
        {
            // declares the users input integer
            int userNum;
            // declare and define a list inputOptions
            List<int> inputOptions = new List<int>();
            //lopps through the adding the options for the menu starting at 1.
            for (int i = 1; i <= numberOfPasses; i++)
            {
                inputOptions.Add(i);
            }
            // check to see if the user input is infact of type int32
            if(Int32.TryParse(Console.ReadLine(),out userNum))
            {
                // checks to see if the user input was in the inputOptions list
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
        // Once a user has selected an option the appropriate method is called
        void handleMainMenuOption(int option)
        {
            switch (option)
            {
                case 1:
                    addTask();
                    break;
                case 2:
                    readTask();
                    break;
                case 3:
                    updateTask();
                    break;
                case 4:
                    deleteTask();
                    break;
                case 5:
                    completeTaskChange();
                    break;
                case 6:
                    System.Console.WriteLine(" Exiting program. ");
                    this.runProgram = false;
                    break;
                default:
                    throw new Exception(" No Option was selected. ");
            }
        }
        // method to handle user request to add a to do item
        // trys to add a to do item to the database and save
        // if it fails it will throw an exception without saving
        void addTask()
        {
            try
            {
                toDoContext.to_do_item.Add(ToDoItem.createTask());
                toDoContext.SaveChanges();
            }
            catch
            {
                System.Console.WriteLine(" An error was encountered when adding the task! ");
            }
        }
        void readTask()
        {
            displayList();
        }
        // Function to update a user selected task.
        void updateTask()
        {
            // tries to get the users item id, if a valid id is selected
            // the handleTaskUpdate function is called to manage the users 
            // requested changes.
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
                    toDoContext.SaveChanges();
                }
            }
            catch
            {
                System.Console.WriteLine("This was not a valid record to update. Please try again");
            }
        }
        // function called when the user indicates that they would like to delete a task from their list.
        void deleteTask()
        {
            System.Console.WriteLine(" Please enter the task number you would like to delete. ");
            // trys calling the delete function to remove the selected task id if it exists
            try
            {
                userTaskDelete(Console.ReadLine());
            }
            catch
            {
                System.Console.WriteLine(" That was not a valid task to delete! ");
            }
        }
        // this is the task that is called by deleteTask, if the user input is a valid task id it will
        // delete the task from the database and save.
        void userTaskDelete(string userInput)
        {            
            int userInt;
            // checks if the user input is convertable to type integer
            if (Int32.TryParse(userInput, out userInt))
            {
                // checks to see if the id entered contains a valid object to delete
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
        // Is called by updateTask, first displays the selected task and contents
        // asks the user if they would like to update the name and detail for the task.
        ToDoItem handleTaskUpdate(ToDoItem updateTask)
        {
            System.Console.WriteLine("");
            displayList(updateTask);
            System.Console.WriteLine("");
            System.Console.WriteLine("Would you like to change the Task Name \"Y\" or \"n\"?");
            // if y is entered then the return is true and the following code is executed to update the task name
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
            // if y is entered then the return is true and the following code is executed to update the task detail
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
            
            // functionality that needs to be added for due dates
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
        // simple function that gets the task by its id
        ToDoItem getItemById(int taskId)
        {
            return toDoContext.to_do_item.Find(taskId);
        }
        // Function to handle when the user would like to complete a task in the system.
        void completeTaskChange()
        {
            int task;
            System.Console.WriteLine("");
            System.Console.WriteLine("Please select the task you wish to complete or change back to incomplete.");
            string taskNum = Console.ReadLine();
            // checks to see if the users input is an integer
            if (Int32.TryParse(taskNum, out task))
            {
                // if it is an integer it confirms that there is a task at that id
                if (getItemById(task) != null)
                {
                    // starts loging any potential changes
                    toDoContext.to_do_item.Update(getItemById(task));
                    // if the task was already complete then the user is wanting to make the task active again
                    if (getItemById(task).taskComplete == true)
                    {
                        getItemById(task).taskComplete = false;
                    }
                    // if the task is incomplete then the user would like to complete the task
                    else if (getItemById(task).taskComplete == false)
                    {
                        getItemById(task).taskComplete = true;
                    }
                    // saves the changes to the task to the database
                    toDoContext.SaveChanges();
                }
                else
                {
                    throw new Exception("there is no task at that record");
                }
            }
            else
            {
                throw new Exception("The entry was not a integer");
            }
        }
        // function to get the users input and test if they entered a valid command to execute the following code
        bool yesNoInput(string userInput)
        {
            if (userInput.ToUpper() == "Y" || userInput.ToUpper() == "YES")
            {
                System.Console.WriteLine("returned true");
                return true;
            }
            else if (userInput.ToUpper() == "N" || userInput.ToUpper() == "NO")
            {
                System.Console.WriteLine("returned false");
                return false;
            }
            else
            {
                throw new Exception("The user didnt enter \"Y\" or \"n\" when updating the task item.");
            }
        }
    }
}