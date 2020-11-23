using System.Linq;
using TuduManayer.Domain.Todo.Update;

namespace TuduManayer.Repository.Postgres.EntityFramework.Todo.Update
{
    public class UpdateTodoRepository : IUpdateTodoRepository
    {
        private readonly DataBaseContextFactory dataBaseContextFactory;

        public UpdateTodoRepository(DataBaseContextFactory dataBaseContextFactory)
        {
            this.dataBaseContextFactory = dataBaseContextFactory;
        }

        public void Update(Domain.Todo.Update.Models.Todo todo)
        {
            using var dbContext = dataBaseContextFactory.Create();
            var entity = dbContext.Todos.First(x => x.id == todo.Id);
            entity.title = todo.Title;
            entity.description = todo.Description;
            dbContext.SaveChanges();
        }
    }
}