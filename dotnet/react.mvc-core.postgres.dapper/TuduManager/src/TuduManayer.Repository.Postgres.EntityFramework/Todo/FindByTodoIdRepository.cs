using TuduManayer.Domain.Todo.FindById;

namespace TuduManayer.Repository.Postgres.EntityFramework.Todo
{
    public class FindByTodoIdRepository : IFindByTodoIdRepository
    {
        public Domain.Todo.FindById.Models.Todo Find(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}