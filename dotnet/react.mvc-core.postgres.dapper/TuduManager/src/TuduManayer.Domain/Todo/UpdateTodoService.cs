using System;
using System.Collections.Generic;

namespace TuduManayer.Domain.Todo
{
    public interface IUpdateTodoService
    {
        ServiceExecutionResult Update(TodoUpdatingArgs todoUpdatingArgs);
    }

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

    public class UpdateTodoService : IUpdateTodoService
    {
        public static int MaximumNumberOfCharacters = 255;
        
        public ServiceExecutionResult Update(TodoUpdatingArgs todoUpdatingArgs)
        {
            var errors = new List<Error>();
            if (string.IsNullOrWhiteSpace(todoUpdatingArgs.Title))
                errors.Add(
                    Error.With(nameof(todoUpdatingArgs.Title), ErrorCodes.Required));
            else if (todoUpdatingArgs.Title.Length > MaximumNumberOfCharacters)
            {
                errors.Add(
                    Error.With(nameof(todoUpdatingArgs.Title), ErrorCodes.InvalidLength));
            }
            
            if (!string.IsNullOrEmpty(todoUpdatingArgs.Description) && todoUpdatingArgs.Description.Length > MaximumNumberOfCharacters)
            {
                errors.Add(
                    Error.With(nameof(todoUpdatingArgs.Description), ErrorCodes.InvalidLength));
            }
            return ServiceExecutionResult.WithErrors(errors);
                throw new NotImplementedException();
        }
    }
}