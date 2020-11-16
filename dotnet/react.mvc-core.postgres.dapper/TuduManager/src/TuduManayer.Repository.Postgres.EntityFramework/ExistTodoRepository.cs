using TuduManayer.Domain.Todo.Delete;

namespace TuduManayer.Repository.Postgres.EntityFramework
{
    public class ExistTodoRepository : IExistTodoRepository
    {
        public bool Exist(int todoId)
        {
            throw new System.NotImplementedException();
        }
    }
}