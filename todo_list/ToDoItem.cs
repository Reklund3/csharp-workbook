using System;


namespace todo_list
{
    class ToDoItem
    {
        public string taskName { get; private set; }
        public string taskDetail { get; private set; }
        public DateTime dueDate { get; private set; }
        public ToDoItem()
        {
            setTaskName();
            setTaskDetail();
        }
        public void setTaskName()
        {
            do{
                try
                {
                    System.Console.WriteLine("Please enter the please handle item.");
                    System.Console.WriteLine("There is a character limit of 30");
                    this.taskName = getInput(30);
                }
                catch (Exception)
                {
                    System.Console.WriteLine("There was an error with the \"Task Name\" Please try again");
                }
            } while(true);
        }
        public void setTaskDetail()
        {
            do{
                try
                {
                    System.Console.WriteLine("Please enter the please handle item.");
                    System.Console.WriteLine("There is a character limit of 30");
                    this.taskName = getInput(30);
                }
                catch (Exception)
                {
                    System.Console.WriteLine("There was an error with the \"Task Name\" Please try again");
                }
            } while(true);
        }
        public string getInput(int stringLength)
        {
            string userInput = Console.ReadLine();
            if (userInput.Length > stringLength)
            {
                throw new Exception("The user input exceeded the length of the field length in table");
            }
            else if (userInput == String.Empty)
            {
                throw new Exception("The user didnt enter a task name to the field");
            }
            else
            {
                return userInput;
            }
        }
    }
}