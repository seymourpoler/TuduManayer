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
        private Mock<ICreateTodoService> createTodoService;
        private CreateTodoController controller;
        
        public CreateTodoControllerShould()
        {
            createTodoService = new Mock<ICreateTodoService>();
            controller = new CreateTodoController(createTodoService.Object);
        }

        [Fact]
        public void return_bad_request_when_there_are_errors()
        {
            createTodoService
                .Setup(x => x.Create(It.Is<TodoCreationArgs>(x => x.Title == string.Empty)))
                .Returns(ServiceExecutionResult.WithErrors(new List<Error>{Error.With(nameof(TodoCreationArgs.Title), ErrorCodes.Required)}));
            var request = new TodoCreationRequest{Title = string.Empty, Description = "simple description"};
            
            var response = controller.Create(request) as BadRequestObjectResult;
            
            response.StatusCode.ShouldBe((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public void return_ok_when_todo_is_created()
        {
            createTodoService
                .Setup(x => x.Create(It.IsAny<TodoCreationArgs>()))
                .Returns(ServiceExecutionResult.WithSucess());
            var request = new TodoCreationRequest{Title = "title", Description = "simple description"};
            
            var response = controller.Create(request) as OkResult;
            
            response.StatusCode.ShouldBe((int)HttpStatusCode.OK);
        }
    }
}