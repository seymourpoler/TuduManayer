using System;
using System.Collections.Generic;

namespace TuduManayer.Domain.Todo.Create
{
    public interface ICreateTodoService
    {
        ServiceExecutionResult Create(TodoCreationArgs todoCreationArgs);
    }

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

    public class CreateTodoService : ICreateTodoService
    {
        public static int MaximumNumberOfCharacters = 255;
        
        public ServiceExecutionResult Create(TodoCreationArgs todoCreationArgs)
        {
            if (string.IsNullOrWhiteSpace(todoCreationArgs.Title))
                return ServiceExecutionResult.WithErrors(new List<Error>
                    {Error.With(nameof(todoCreationArgs.Title), ErrorCodes.Required)});

            var errors = new List<Error>();
            if (todoCreationArgs.Title.Length > MaximumNumberOfCharacters)
                errors.Add(Error.With(nameof(todoCreationArgs.Title), ErrorCodes.InvalidLength));

            if (todoCreationArgs.Description.Length > MaximumNumberOfCharacters)
                errors.Add(Error.With(nameof(todoCreationArgs.Description), ErrorCodes.InvalidLength));

            if (errors.IsNotEmpty()){
                return ServiceExecutionResult.WithErrors(errors);
            }
            
            throw new NotImplementedException();
        }
    }
}