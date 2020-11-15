using Moq;
using MyTested.AspNetCore.Mvc;
using TuduManayer.web.api.Todo.Create;
using TuduManayer.web.api.Todo.Delete;
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
                    x.Create(It.IsAny<TodoCreationRequest>()));
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
    }
}