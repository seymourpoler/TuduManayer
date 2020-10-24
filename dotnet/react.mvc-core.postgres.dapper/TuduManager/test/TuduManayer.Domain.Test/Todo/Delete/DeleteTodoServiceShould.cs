using Moq;
using Shouldly;
using TuduManayer.Domain.Todo.Delete;
using Xunit;

namespace TuduManayer.Domain.Test.Todo.Delete
{
    public class DeleteTodoServiceShould
    {
        private Mock<IExistTodoRepository> existRepository;
        private IDeleteTodoService service;

        public DeleteTodoServiceShould()
        {
            existRepository = new Mock<IExistTodoRepository>();
            service = new DeleteTodoService(existRepository.Object);
        }

        [Fact]
        public void return_error_when_todo_is_not_found()
        {
            const int someTodoId = 3;
            existRepository
                .Setup(x => x.Exist(someTodoId))
                .Returns(false);

            var result = service.Delete(someTodoId);
            
            result.IsOk.ShouldBeFalse();
        }
    }
}