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
        public ServiceExecutionResult Update(TodoUpdatingArgs todoUpdatingArgs)
        {
            var errors = new List<Error>();
            if (string.IsNullOrWhiteSpace(todoUpdatingArgs.Title))
                errors.Add(
                    Error.With(nameof(todoUpdatingArgs.Title), ErrorCodes.Required));
            if (todoUpdatingArgs.Title.Length > 255)
            {
                errors.Add(
                    Error.With(nameof(todoUpdatingArgs.Title), ErrorCodes.Required));
            }
            
            if (todoUpdatingArgs.Description.Length > 255)
            {
                errors.Add(
                    Error.With(nameof(todoUpdatingArgs.Description), ErrorCodes.InvalidLength));
            }
            return ServiceExecutionResult.WithErrors(errors);
                throw new NotImplementedException();
        }
    }
}