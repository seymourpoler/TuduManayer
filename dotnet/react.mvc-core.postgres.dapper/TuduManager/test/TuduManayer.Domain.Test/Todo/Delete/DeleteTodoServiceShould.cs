using Moq;
using Shouldly;
using TuduManayer.Domain.Todo;
using TuduManayer.Domain.Todo.Delete;
using Xunit;

namespace TuduManayer.Domain.Test.Todo.Delete
{
    public class DeleteTodoServiceShould
    {
        private Mock<IExistTodoRepository> existRepository;
        private Mock<IDeleteTodoRepository> deleteRepository;
        private IDeleteTodoService service;

        public DeleteTodoServiceShould()
        {
            existRepository = new Mock<IExistTodoRepository>();
            deleteRepository = new Mock<IDeleteTodoRepository>();
            service = new DeleteTodoService(existRepository.Object, deleteRepository.Object);
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
        
        [Fact]
        public void delete_todo()
        {
            const int someTodoId = 3;
            existRepository
                .Setup(x => x.Exist(someTodoId))
                .Returns(true);

            var result = service.Delete(someTodoId);
            
            result.IsOk.ShouldBeTrue();
            deleteRepository.Verify(x => x.Delete(someTodoId));
        }
    }
}