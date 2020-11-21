namespace TuduManayer.Domain.Todo.Update
{
    public class TodoUpdatingArgs
    {
        public TodoUpdatingArgs(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
    }
}