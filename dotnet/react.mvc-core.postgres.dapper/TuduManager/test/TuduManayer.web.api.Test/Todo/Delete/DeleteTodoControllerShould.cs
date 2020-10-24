using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using TuduManayer.Domain;
using TuduManayer.Domain.Todo.Delete;
using TuduManayer.web.api.Todo.Delete;
using Xunit;

namespace TuduManayer.web.api.Test.Todo.Delete
{
    public class DeleteTodoControllerShould
    {
        private DeleteTodoController controller;
        private Mock<IDeleteTodoService> service;

        public DeleteTodoControllerShould()
        {
            service = new Mock<IDeleteTodoService>();
            controller = new DeleteTodoController(service.Object);
        }

        [Fact]
        public void return_not_found_when_there_is_an_error()
        {
            const int someTodoId = 4;
            service
                .Setup(x => x.Delete(someTodoId))
                .Returns(ServiceExecutionResult.WithErrors());

            var response = controller.Delete(someTodoId) as NotFoundResult;
            
            response.StatusCode.ShouldBe((int)HttpStatusCode.NotFound);
        }
        
        [Fact]
        public void return_ok()
        {
            const int someTodoId = 4;
            service
                .Setup(x => x.Delete(someTodoId))
                .Returns(ServiceExecutionResult.WithSucess());

            var response = controller.Delete(someTodoId) as OkResult;
            
            response.StatusCode.ShouldBe((int)HttpStatusCode.OK);
        }
    }
}