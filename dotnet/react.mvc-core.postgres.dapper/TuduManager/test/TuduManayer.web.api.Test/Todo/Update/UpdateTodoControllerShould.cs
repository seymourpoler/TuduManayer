using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using TuduManayer.Domain;
using TuduManayer.Domain.Todo;
using TuduManayer.web.api.Todo.Update;
using Xunit;

namespace TuduManayer.web.api.Test.Todo.Update
{
    public class UpdateTodoControllerShould
    {
        [Fact]
        public void return_error_when_there_are_errors()
        {
            const string title = "title";
            var service = new Mock<IUpdateTodoService>();
            service
                .Setup(x => x.Update(It.Is<TodoUpdatingArgs>(y => y.Title == title)))
                .Returns(ServiceExecutionResult.WithErrors(new List<Error>{Error.With(nameof(TodoUpdatingArgs.Title), ErrorCodes.Required)}));
            var controller = new UpdateTodoController(service.Object);
            var request = new TodoUpdatingRequest{Id = 1, Title = title};
            
            var response = controller.Update(request) as BadRequestObjectResult;
            
            response.StatusCode.ShouldBe((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public void return_ok()
        {
            const int someId = 1;
            var service = new Mock<IUpdateTodoService>();
            service
                .Setup(x => x.Update(It.Is<TodoUpdatingArgs>(y => y.Id == someId)))
                .Returns(ServiceExecutionResult.WithSucess());
            var controller = new UpdateTodoController(service.Object);
            var request = new TodoUpdatingRequest{Id = someId, Title = "some title", Description = "some description"};
            
            var response = controller.Update(request) as OkResult;
            
            response.StatusCode.ShouldBe((int)HttpStatusCode.OK);
        }
    }
}