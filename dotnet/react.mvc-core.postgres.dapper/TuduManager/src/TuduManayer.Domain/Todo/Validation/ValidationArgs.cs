namespace TuduManayer.Domain.Todo.Validation
{
    public class ValidationArgs
    {
        public string Title { get; }
        public string Description { get; }
        
        public ValidationArgs(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}