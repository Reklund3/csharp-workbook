using System;
using Microsoft.EntityFrameworkCore;

namespace todo_list
{
    public class ToDoListContext : DbContext
    {
        public DbSet<ToDoItem> to_do_item { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./todo.db");
        }
    }
}