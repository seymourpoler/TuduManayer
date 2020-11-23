using System.Linq;
using TuduManayer.Domain.Todo.Delete;

namespace TuduManayer.Repository.Postgres.EntityFramework.Todo.Delete
{
    public class DeleteTodoRepository : IDeleteTodoRepository
    {
        private readonly DataBaseContextFactory dataBaseContextFactory;

        public DeleteTodoRepository(DataBaseContextFactory dataBaseContextFactory)
        {
            this.dataBaseContextFactory = dataBaseContextFactory;
        }

        public void Delete(int todoId)
        {
            using var dbContext = dataBaseContextFactory.Create();
            var todo = dbContext.Todos.Single(x => x.id == todoId);
            dbContext.Todos.Remove(todo);
            dbContext.SaveChanges();
        }
    }
}