using Moq;
using Shouldly;
using TuduManayer.Domain.Todo;
using TuduManayer.Domain.Todo.FindById;
using Xunit;

namespace TuduManayer.Domain.Test.Todo.FindById
{
    public class FindByIdServiceShould
    {
        Mock<IExistTodoRepository> existRepository;
        Mock<IFindByTodoIdRepository> findRepository;

        private IFindByTodoIdService findService;
        
        public FindByIdServiceShould()
        {
            existRepository = new Mock<IExistTodoRepository>();
            findRepository = new Mock<IFindByTodoIdRepository>();
            findService = new FindByTodoIdService(
                existRepository.Object,
                findRepository.Object);
        }
        
        [Fact]
        public void return_not_found_when_is_not_found()
        {
            const int someTodoId = 3;
            Mock<IExistTodoRepository> existRepository = new Mock<IExistTodoRepository>();
            existRepository
                .Setup(x => x.Exist(someTodoId))
                .Returns(false);

            var result = findService.Find(someTodoId);
            
            result.IsOk.ShouldBeFalse();
        }
        
        [Fact]
        public void return_found_todo()
        {
            const int someTodoId = 3;
            const string title = "some title";
            existRepository
                .Setup(x => x.Exist(someTodoId))
                .Returns(true);
            findRepository
                .Setup(x => x.Find(someTodoId))
                .Returns(new Domain.Todo.FindById.Models.Todo(someTodoId, title, "Description"));

            var result = findService.Find(someTodoId);
            
            result.IsOk.ShouldBeTrue();
            result.Model.Id.ShouldBe(someTodoId);
            result.Model.Title.ShouldBe(title);
        }
    }
}