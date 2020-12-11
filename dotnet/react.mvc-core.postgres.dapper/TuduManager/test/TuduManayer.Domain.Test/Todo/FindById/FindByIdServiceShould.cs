using Moq;
using Shouldly;
using TuduManayer.Domain.Todo;
using TuduManayer.Domain.Todo.FindById;
using Xunit;

namespace TuduManayer.Domain.Test.Todo.FindById
{
    public class FindByIdServiceShould
    {
        [Fact]
        public void return_not_found_when_is_not_found()
        {
            const int someTodoId = 3;
            Mock<IExistTodoRepository> existRepository = new Mock<IExistTodoRepository>();
            existRepository
                .Setup(x => x.Exist(someTodoId))
                .Returns(false);
            var service = new FindByTodoIdService(existRepository.Object);

            var result = service.Find(someTodoId);
            
            result.IsOk.ShouldBeFalse();
        }
    }
}