using System.Collections.Generic;
using System.Linq;
using TuduManayer.Domain.Todo.Search;

namespace TuduManayer.Repository.Postgres.EntityFramework.Todo.Search
{
    public class SearchTodoRepository : ISearchTodoRepository
    {
        private readonly DataBaseContextFactory dataBaseContextFactory;

        public SearchTodoRepository(DataBaseContextFactory dataBaseContextFactory)
        {
            this.dataBaseContextFactory = dataBaseContextFactory;
        }

        public IReadOnlyCollection<Domain.Todo.Search.Models.Todo> Search(string searchText)
        {
            using var dbContext = dataBaseContextFactory.Create();
            return dbContext.Todos
                .ToList()
                .Where(x => x.title.Contains(searchText) || x.description.Contains(searchText))
                .Select(x => new Domain.Todo.Search.Models.Todo {Id = x.id, Title = x.title})
                .ToList()
                .AsReadOnly();
        }
    }
}