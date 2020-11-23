using TuduManayer.Domain.Todo.Update;

namespace TuduManayer.Repository.Postgres.EntityFramework.Todo.Update
{
    public class FindTodoRepository : IFindTodoRepository
    {
        public Domain.Todo.Update.Models.Todo FindById(int todoId)
        {
            throw new System.NotImplementedException();
        }
    }
}