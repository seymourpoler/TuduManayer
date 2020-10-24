namespace TuduManayer.Domain.Todo.Delete
{
    public interface IDeleteTodoService
    {
        ServiceExecutionResult Delete(int todoId);
    }
    
    public class DeleteTodoService : IDeleteTodoService
    {
        private readonly IExistTodoRepository existTodoRepository;
        private readonly IDeleteTodoRepository deleteRepository;

        public DeleteTodoService(IExistTodoRepository existTodoRepository, IDeleteTodoRepository deleteRepository)
        {
            this.existTodoRepository = existTodoRepository;
            this.deleteRepository = deleteRepository;
        }

        public ServiceExecutionResult Delete(int todoId)
        {
            if (!existTodoRepository.Exist(todoId))
            {
                return ServiceExecutionResult.WithErrors();
            }
            
            deleteRepository.Delete(todoId);
            return ServiceExecutionResult.WithSucess();
        }
    }
}