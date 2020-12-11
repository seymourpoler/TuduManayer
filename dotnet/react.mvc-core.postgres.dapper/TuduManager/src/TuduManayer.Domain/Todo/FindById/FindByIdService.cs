namespace TuduManayer.Domain.Todo.FindById
{
    public interface IFindByTodoIdService
    {
        ServiceExecutionResultWithModel<Models.Todo> Find(int id);
    }
    
    public class FindByTodoIdService : IFindByTodoIdService
    {
        private readonly IExistTodoRepository existTodoRepository;

        public FindByTodoIdService(IExistTodoRepository existTodoRepository)
        {
            this.existTodoRepository = existTodoRepository;
        }

        public ServiceExecutionResultWithModel<Models.Todo> Find(int id)
        {
            if(!existTodoRepository.Exist(id)) return ServiceExecutionResultWithModel<Models.Todo>.WitError();
            throw new System.NotImplementedException();
        }
    }
}