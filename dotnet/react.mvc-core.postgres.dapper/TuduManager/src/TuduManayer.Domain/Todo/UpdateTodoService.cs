using System;
using System.Collections.Generic;
using TuduManayer.Domain.Todo.Delete;

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
        
        private readonly IExistTodoRepository existTodoRepository;
        
        public UpdateTodoService(IExistTodoRepository existTodoRepository)
        {
            this.existTodoRepository = existTodoRepository;
        }

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

            if (errors.IsNotEmpty())
            {
                return ServiceExecutionResult.WithErrors(errors);
            }

            if (IsNotExistTodo(todoUpdatingArgs.Id))
            {
                return ServiceExecutionResult.WithErrors(new List<Error> {
                        Error.With(nameof(todoUpdatingArgs.Id), ErrorCodes.NotFound)});
            }
            throw new NotImplementedException();
        }

        private bool IsNotExistTodo(int todoId)
        {
            return !existTodoRepository.Exist(todoId);
        }
    }
}