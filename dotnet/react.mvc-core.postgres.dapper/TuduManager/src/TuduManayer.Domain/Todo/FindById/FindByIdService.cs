namespace TuduManayer.Domain.Todo.FindById
{
    public interface IFindByTodoIdService
    {
        ServiceExecutionResultWithModel<Models.Todo> Find(int id);
    }
    
    public class FindByTodoIdService : IFindByTodoIdService
    {
        private readonly IExistTodoRepository existTodoRepository;
        private readonly IFindByTodoIdRepository findByTodoIdRepository;

        public FindByTodoIdService(
            IExistTodoRepository existTodoRepository,
            IFindByTodoIdRepository findByTodoIdRepository)
        {
            this.existTodoRepository = existTodoRepository;
            this.findByTodoIdRepository = findByTodoIdRepository;
        }

        public ServiceExecutionResultWithModel<Models.Todo> Find(int id)
        {
            if(!existTodoRepository.Exist(id)) return ServiceExecutionResultWithModel<Models.Todo>.WitError();

            var todo = findByTodoIdRepository.Find(id);
            return ServiceExecutionResultWithModel<Models.Todo>.With(todo);
        }
    }
}