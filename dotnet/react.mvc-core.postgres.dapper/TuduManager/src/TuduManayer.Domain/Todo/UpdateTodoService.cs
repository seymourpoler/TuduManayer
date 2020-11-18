namespace TuduManayer.Domain.Todo
{
    public interface IUpdateTodoService
    {
        ServiceExecutionResult Update(TodoUpdatingArgs todoUpdatingArgs);
    }

    public class TodoUpdatingArgs
    {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        
        public TodoUpdatingArgs(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }

    public class UpdateTodoService : IUpdateTodoService
    {
        public ServiceExecutionResult Update(TodoUpdatingArgs todoUpdatingArgs)
        {
            throw new System.NotImplementedException();
        }
    }
}