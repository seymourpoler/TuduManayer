namespace TuduManayer.Domain.Todo.Update.Models
{
    public class Todo
    {
        public int Id { get; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        
        public Todo(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public void Update(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}