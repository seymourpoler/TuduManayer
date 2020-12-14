using System.Linq;
using TuduManayer.Domain.Todo.FindById;

namespace TuduManayer.Repository.Postgres.EntityFramework.Todo.FindByTodoId
{
    public class FindByTodoIdRepository : IFindByTodoIdRepository
    {
        private readonly DataBaseContextFactory dataBaseContextFactory;

        public FindByTodoIdRepository(DataBaseContextFactory dataBaseContextFactory)
        {
            this.dataBaseContextFactory = dataBaseContextFactory;
        }

        public Domain.Todo.FindById.Models.Todo Find(int id)
        {
            using var dbContext = dataBaseContextFactory.Create();
            var entity = dbContext.Todos.Single(x => x.id == id);
            return new Domain.Todo.FindById.Models.Todo(id, entity.title, entity.description);
        }
    }
}