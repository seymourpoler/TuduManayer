using System.Net;
using Moq;
using MyTested.AspNetCore.Mvc;
using TuduManayer.web.api.Todo.Create;
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
                    .WithMethod(WebRequestMethods.Http.Post)
                    .WithLocation("/api/todos"))
                .To<CreateTodoController>(x => 
                    x.Create(It.IsAny<TodoCreationRequest>()));
        }
    }
}