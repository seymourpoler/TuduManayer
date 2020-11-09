using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using TuduManayer.Domain;
using TuduManayer.Domain.Todo.Create;
using TuduManayer.web.api.Todo.Create;
using Xunit;

namespace TuduManayer.web.api.Test.Todo.Create
{
    public class CreateTodoControllerShould
    {
        [Fact]
        public void return_bad_request_when_there_are_errors()
        {
            var createTodoService = new Mock<ICreateTodoService>();
            createTodoService
                .Setup(x => x.Create(It.Is<TodoCreationArgs>(x => x.Title == string.Empty)))
                .Returns(ServiceExecutionResult.WithErrors(new List<Error>{Error.With(nameof(TodoCreationArgs.Title), ErrorCodes.Required)}));
            var controller = new CreateTodoController(createTodoService.Object);
            var request = new TodoCreationRequest{Title = string.Empty, Description = "simple description"};
            
            var response = controller.Create(request) as BadRequestObjectResult;
            
            response.StatusCode.ShouldBe((int)HttpStatusCode.BadRequest);
        }
    }
}