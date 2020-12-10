using System.Linq;
using TuduManayer.Domain.Todo;

namespace TuduManayer.Repository.Postgres.EntityFramework.Todo
{
    public class ExistTodoRepository : IExistTodoRepository
    {
        private readonly DataBaseContextFactory dataBaseContextFactory;

        public ExistTodoRepository(DataBaseContextFactory dataBaseContextFactory)
        {
            this.dataBaseContextFactory = dataBaseContextFactory;
        }

        public bool Exist(int todoId)
        {
            using var dbContext = dataBaseContextFactory.Create();
            return dbContext.Todos.Any(x => x.id == todoId);
        }
    }
}