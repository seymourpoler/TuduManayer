using TuduManayer.Domain.Todo.Update;

namespace TuduManayer.Domain.Todo.FindById
{
    
    public interface IFindByTodoIdService
    {
        ServiceExecutionResultWithModel<Models.Todo> Find(int id);
    }
    
    public class FindByTodoIdService : IFindByTodoIdService
    {
        public ServiceExecutionResultWithModel<Models.Todo> Find(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}