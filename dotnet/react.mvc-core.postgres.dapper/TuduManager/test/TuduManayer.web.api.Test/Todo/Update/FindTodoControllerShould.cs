using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using TuduManayer.Domain;
using TuduManayer.Domain.Todo.FindById;
using TuduManayer.web.api.Todo.Update;
using Xunit;

namespace TuduManayer.web.api.Test.Todo.Update
{
    public class FindTodoControllerShould
    {
        [Fact]
        public void return_not_found_when_is_not_found()
        {
            const int someTodoId = 2;
            Mock<IFindByTodoIdService> service = new Mock<IFindByTodoIdService>();
            service
                .Setup(x => x.Find(someTodoId))
                .Returns(ServiceExecutionResultWithModel<TuduManayer.Domain.Todo.FindById.Models.Todo>.WitError());
            var controller = new FindByTodoIdController(service.Object);
            
            var response = controller.Find(someTodoId) as NotFoundResult;
            
            response.StatusCode.ShouldBe((int)HttpStatusCode.NotFound);
        } 
    }
}