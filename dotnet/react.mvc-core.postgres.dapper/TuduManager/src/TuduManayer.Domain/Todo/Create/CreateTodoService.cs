using TuduManayer.Domain.Todo.Validation;

namespace TuduManayer.Domain.Todo.Create
{
    public interface ICreateTodoService
    {
        ServiceExecutionResult Create(TodoCreationArgs todoCreationArgs);
    }

    public class CreateTodoService : ICreateTodoService
    {
        private readonly Validator validator;
        private readonly ISaveTodoRepository repository;
        
        public CreateTodoService(ISaveTodoRepository saveTodoRepository, Validator validator)
        {
            repository = saveTodoRepository;
            this.validator = validator;
        }

        public ServiceExecutionResult Create(TodoCreationArgs todoCreationArgs)
        {
            var validationArgs = new ValidationArgs(todoCreationArgs.Title, todoCreationArgs.Description);
            var errors = validator.Validate(validationArgs);

            if (errors.IsNotEmpty()){
                return ServiceExecutionResult.WithErrors(errors);
            }
            
            var todo = new Create.Models.Todo(todoCreationArgs.Title, todoCreationArgs.Description);
            repository.Save(todo);
            
            return ServiceExecutionResult.WithSucess();
        }
    }
}