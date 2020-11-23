using System;

namespace TuduManayer.Domain.Todo.Create.Models
{
    public class Todo
    {
        public string Title { get; }
        public string Description { get; }
        public DateTime CreationDate { get; }
        
        public Todo(string title, string description)
        {
            Title = title;
            Description = description;
            CreationDate = DateTime.Now;
        }
    }
}