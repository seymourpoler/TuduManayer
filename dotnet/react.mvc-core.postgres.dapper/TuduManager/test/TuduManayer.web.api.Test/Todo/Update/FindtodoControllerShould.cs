using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using TuduManayer.Domain.Todo.FindById;
using TuduManayer.web.api.Todo.Update;
using Xunit;

namespace TuduManayer.web.api.Test.Todo.Update
{
    public class FindtodoControllerShould
    {
        [Fact]
        public void return_not_found_when_is_not_found()
        {
            Mock<IFindByTodoIdService> service = new Mock<IFindByTodoIdService>();
            var controller = new FindByTodoIdController(service.Object);
            const int someTodoId = 2;
            
            var response = controller.Find(someTodoId) as NotFoundObjectResult;
            
            response.StatusCode.Value.ShouldBe((int)HttpStatusCode.NotFound);
        } 
    }
}