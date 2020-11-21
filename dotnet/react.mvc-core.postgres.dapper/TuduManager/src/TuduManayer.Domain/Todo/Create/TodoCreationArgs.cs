namespace TuduManayer.Domain.Todo.Create
{
    public class TodoCreationArgs
    {
        public TodoCreationArgs(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; }
        public string Description { get; }
    }
}