using System;
using System.Collections.Generic;

namespace TuduManayer.Domain.Todo.Create
{
    public interface ICreateTodoService
    {
        ServiceExecutionResult Create(TodoCreationArgs todoCreationArgs);
    }

    public class CreateTodoService : ICreateTodoService
    {
        public static int MaximumNumberOfCharacters = 255;

        private readonly ISaveTodoRepository repository;
        
        public CreateTodoService(ISaveTodoRepository saveTodoRepository)
        {
            repository = saveTodoRepository;
        }

        public ServiceExecutionResult Create(TodoCreationArgs todoCreationArgs)
        {
            var errors = new List<Error>();
            if (string.IsNullOrWhiteSpace(todoCreationArgs.Title))
            {
                errors.Add(Error.With(nameof(todoCreationArgs.Title), ErrorCodes.Required));
            }
            else if (todoCreationArgs.Title.Length > MaximumNumberOfCharacters)
                errors.Add(Error.With(nameof(todoCreationArgs.Title), ErrorCodes.InvalidLength));

            if (!string.IsNullOrWhiteSpace(todoCreationArgs.Description) && todoCreationArgs.Description.Length > MaximumNumberOfCharacters)
                errors.Add(Error.With(nameof(todoCreationArgs.Description), ErrorCodes.InvalidLength));

            if (errors.IsNotEmpty()){
                return ServiceExecutionResult.WithErrors(errors);
            }
            
            var todo = new Create.Models.Todo(todoCreationArgs.Title, todoCreationArgs.Description);
            repository.Save(todo);
            
            return ServiceExecutionResult.WithSucess();
        }
    }
}