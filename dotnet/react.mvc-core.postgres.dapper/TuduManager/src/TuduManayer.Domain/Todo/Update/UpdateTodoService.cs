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
        private readonly IFindTodoRepository findTodoRepository;
        private readonly IUpdateTodoRepository updateTodoRepository;

        public UpdateTodoService(IExistTodoRepository existTodoRepository,
            Validator validator,
            IFindTodoRepository findTodoRepository, 
            IUpdateTodoRepository updateTodoRepository)
        {
            this.existTodoRepository = existTodoRepository;
            this.validator = validator;
            this.findTodoRepository = findTodoRepository;
            this.updateTodoRepository = updateTodoRepository;
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

            var todo = findTodoRepository.FindById(todoUpdatingArgs.Id);
            todo.Update(validationArgs.Title, validationArgs.Description);
            updateTodoRepository.Update(todo);
            return ServiceExecutionResult.WithSucess();
        }

        private bool IsNotExistTodo(int todoId)
        {
            return !existTodoRepository.Exist(todoId);
        }
    }
}