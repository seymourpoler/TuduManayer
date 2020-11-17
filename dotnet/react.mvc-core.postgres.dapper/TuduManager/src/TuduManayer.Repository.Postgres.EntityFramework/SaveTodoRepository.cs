using TuduManayer.Domain.Todo.Create;

namespace TuduManayer.Repository.Postgres.EntityFramework
{
    public class SaveTodoRepository : ISaveTodoRepository
    {
        private readonly DataBaseContextFactory contextFactory;

        public SaveTodoRepository(DataBaseContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Save(Domain.Todo.Create.Models.Todo todo)
        {
            using var dbContext = contextFactory.Create();
            var entity = new Todo
            {
                title = todo.Title,
                description = todo.Description
            };
            dbContext.Todos.Add(entity);
            dbContext.SaveChanges();
        }
    }
}