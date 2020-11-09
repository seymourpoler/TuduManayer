namespace TuduManayer.Domain.Todo.Create
{
    public interface ICreateTodoService
    {
        ServiceExecutionResult Create(TodoCreationArgs todoCreationArgs);
    }
    
    public class TodoCreationArgs
    {
        public string Title { get; }
        public string Description { get; }

        public TodoCreationArgs(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }

    public class CreateTodoService : ICreateTodoService
    {
        public ServiceExecutionResult Create(TodoCreationArgs todoCreationArgs)
        {
            throw new System.NotImplementedException();
        }
    }
}