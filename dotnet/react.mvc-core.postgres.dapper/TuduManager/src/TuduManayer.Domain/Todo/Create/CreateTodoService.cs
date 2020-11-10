using System.Collections.Generic;

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
            if (todoCreationArgs.Title is null)
            {
                return ServiceExecutionResult.WithErrors(new List<Error>
                    {Error.With(nameof(todoCreationArgs.Title), ErrorCodes.Required)});
            }
            throw new System.NotImplementedException();
        }
    }
}