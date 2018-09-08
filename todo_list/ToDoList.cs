using System;
using System.Collections.Generic;

namespace todo_list
{
    class ToDoList
    {
        List<ToDoItem> toDos;
        public ToDoList()
        {
            toDos = new List<ToDoItem>();
            userOptions();
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
    }
}