namespace TuduManayer.Domain.Todo.Delete
{
    public interface IDeleteTodoService
    {
        ServiceExecutionResult Delete(int todoId);
    }
    
    public class DeleteTodoService : IDeleteTodoService
    {
        private readonly IExistTodoRepository existTodoRepository;

        public DeleteTodoService(IExistTodoRepository existTodoRepository)
        {
            this.existTodoRepository = existTodoRepository;
        }

        public ServiceExecutionResult Delete(int todoId)
        {
            if (existTodoRepository.Exist(todoId))
            {
                throw new System.NotImplementedException();   
            }
            return ServiceExecutionResult.WithErrors();
        }
    }
}