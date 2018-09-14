using System;


namespace todo_list
{
    public class ToDoItem
    {
        public int Id { get; private set; }
        public string taskName { get; set; }
        public string taskDetail { get; set; }
        public DateTime dueDate { get; set; }
        public static ToDoItem createTask()
        {
            string taskName = getTaskName();
            string taskDetail = getTaskDetail();
            ToDoItem item = new ToDoItem();
            item.taskName = taskName;
            item.taskDetail = taskDetail;
            return item;
        }
        static string getTaskName()
        {
            do
            {
                try
                {
                    System.Console.WriteLine("Please enter the TasK Name.");
                    System.Console.WriteLine("There is a character limit of 30");
                    return getInput(30);
                }
                catch (Exception)
                {
                    System.Console.WriteLine("There was an error with the \"Task Name\" Please try again");
                }
            } while(true);
        }
        static string getTaskDetail()
        {
            do{
                try
                {
                    System.Console.WriteLine("Please enter the Task Detail.");
                    System.Console.WriteLine("There is a character limit of 255");
                    return getInput(255);
                }
                catch (Exception)
                {
                    System.Console.WriteLine("There was an error with the \"Task Name\" Please try again");
                }
            } while(true);
        }
        static string getInput(int stringLength)
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