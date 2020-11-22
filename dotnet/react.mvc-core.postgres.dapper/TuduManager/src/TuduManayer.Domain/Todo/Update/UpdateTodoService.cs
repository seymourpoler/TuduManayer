using System;
using System.Collections.Generic;
using TuduManayer.Domain.Todo.Delete;
using TuduManayer.Domain.Todo.Validation;

namespace TuduManayer.Domain.Todo.Update
{
    public interface IUpdateTodoService
    {
        ServiceExecutionResult Update(TodoUpdatingArgs todoUpdatingArgs);
    }

    public class UpdateTodoService : IUpdateTodoService
    {
        private readonly IExistTodoRepository existTodoRepository;
        private readonly Validator validator;
        
        public UpdateTodoService(IExistTodoRepository existTodoRepository, Validator validator)
        {
            this.existTodoRepository = existTodoRepository;
            this.validator = validator;
        }

        public ServiceExecutionResult Update(TodoUpdatingArgs todoUpdatingArgs)
        {
            var validationArgs = new ValidationArgs(todoUpdatingArgs.Title, todoUpdatingArgs.Description);
            var errors = validator.Validate(validationArgs);
            
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