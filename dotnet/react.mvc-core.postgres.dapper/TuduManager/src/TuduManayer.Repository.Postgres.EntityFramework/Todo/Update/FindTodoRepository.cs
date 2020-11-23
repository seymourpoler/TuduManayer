using System.Linq;
using TuduManayer.Domain.Todo.Update;

namespace TuduManayer.Repository.Postgres.EntityFramework.Todo.Update
{
    public class FindTodoRepository : IFindTodoRepository
    {
        private readonly DataBaseContextFactory dataBaseContextFactory;

        public FindTodoRepository(DataBaseContextFactory dataBaseContextFactory)
        {
            this.dataBaseContextFactory = dataBaseContextFactory;
        }

        public Domain.Todo.Update.Models.Todo FindById(int todoId)
        {
            using var dbContext = dataBaseContextFactory.Create();
            var entity = dbContext.Todos.First(x => x.id == todoId);
            return new Domain.Todo.Update.Models.Todo(
                entity.id,
                entity.title,
                entity.description);
        }
    }
}