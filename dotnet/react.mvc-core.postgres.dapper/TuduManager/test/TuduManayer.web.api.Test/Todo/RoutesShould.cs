using MyTested.AspNetCore.Mvc;
using TuduManayer.web.api.Todo.Create;
using TuduManayer.web.api.Todo.Delete;
using TuduManayer.web.api.Todo.Search;
using TuduManayer.web.api.Todo.Update;
using Xunit;

namespace TuduManayer.web.api.Test.Todo
{
    public class RoutesShould
    {
        [Fact]
        public void MapToCreateTodo()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithMethod(HttpMethod.Post)
                    .WithLocation("/api/todos"))
                .To<CreateTodoController>(x =>
                    x.Create(With.Any<TodoCreationRequest>()));
        }

        [Fact]
        public void MapToDeleteTodo()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithMethod(HttpMethod.Delete)
                    .WithLocation("/api/todos/1"))
                .To<DeleteTodoController>(x =>
                    x.Delete(1));
        }

        [Fact]
        public void MapToSearchTodo()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithMethod(HttpMethod.Get)
                    .WithLocation("/api/todos?searchText=aaa"))
                .To<SearchTodoController>(x =>
                    x.Search("aaa"));
        }

        [Fact]
        public void MapToUpdateTodo()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithMethod(HttpMethod.Put)
                    .WithLocation("/api/todos"))
                .To<UpdateTodoController>(x => x.Update(With.Any<TodoUpdatingRequest>()));
        }

        [Fact]
        public void MapToFindTodoById()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithMethod(HttpMethod.Get)
                    .WithLocation("/api/todos/1"))
                .To<FindByTodoIdController>(x => x.Find(1));
        }
    }
}