using System.Linq;
using Moq;
using Shouldly;
using TuduManayer.Domain.Test.Todo.Create;
using TuduManayer.Domain.Todo.Delete;
using TuduManayer.Domain.Todo.Update;
using TuduManayer.Domain.Todo.Validation;
using Xunit;

namespace TuduManayer.Domain.Test.Todo.Update
{
    public class UpdateTodoShould
    {
        private Mock<IExistTodoRepository> existTodoRepository; 
        private IUpdateTodoService service;
        private Mock<IFindTodoRepository> findTodoRepository;
        private Mock<IUpdateTodoRepository> updateTodoRepository;
        
        public UpdateTodoShould()
        {
            existTodoRepository = new Mock<IExistTodoRepository>();
            findTodoRepository = new Mock<IFindTodoRepository>();
            updateTodoRepository = new Mock<IUpdateTodoRepository>();
            service = new UpdateTodoService(
                existTodoRepository.Object,
                new Validator(),
                findTodoRepository.Object,
                updateTodoRepository.Object);
        }

        [Fact]
        public void return_error_when_title_is_null()
        {
            var args = new TodoUpdatingArgs(id:1, title: null, description: "a description");

            var result = service.Update(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.Required);
        }
        
        [Fact]
        public void return_error_when_title_is_string_empty()
        {
            var args = new TodoUpdatingArgs(id:1, title: string.Empty, description: "a description");

            var result = service.Update(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.Required);
        }
        
        [Fact]
        public void return_error_when_title_is_white_space()
        {
            var args = new TodoUpdatingArgs(id:1, title: "  ", description: "a description");

            var result = service.Update(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.Required);
        }

        [Fact]
        public void return_error_when_title_has_more_characters_than_the_maximum_allowed()
        {
            var title = StringGenerator.Generate(Validator.MaximumNumberOfCharacters + 1);
            var args = new TodoUpdatingArgs(id:1, title: title, description: null);

            var result = service.Update(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.InvalidLength);
        }
        
        [Fact]
        public void return_error_when_description_has_more_characters_than_the_maximum_allowed()
        {
            var description = StringGenerator.Generate(Validator.MaximumNumberOfCharacters + 1);
            var args = new TodoUpdatingArgs(id:1, title: "a title", description: description);

            var result = service.Update(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Description));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.InvalidLength);
        }
        
        [Fact] 
        public void return_error_when_title_is_string_empty_and_description_has_more_characters_than_the_maximum_allowed()
        {
            var description = StringGenerator.Generate(Validator.MaximumNumberOfCharacters + 1);
            var args = new TodoUpdatingArgs(id:1, title: string.Empty, description: description);

            var result = service.Update(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.Required);
            result.Errors.Second().FieldId.ShouldBe(nameof(args.Description));
            result.Errors.Second().ErrorCode.ShouldBe(ErrorCodes.InvalidLength);
        }

        [Fact]
        public void return_error_when_todo_is_not_found()
        {
            const int someTodoId = 3;
            existTodoRepository
                .Setup(x => x.Exist(someTodoId))
                .Returns(false);
            var args = new TodoUpdatingArgs(id:someTodoId, title: "a title", description: string.Empty);

            var result = service.Update(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Id));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.NotFound);
        }

        [Fact]
        public void update_todo()
        {
            const int someTodoId = 3;
            existTodoRepository
                .Setup(x => x.Exist(someTodoId))
                .Returns(true);
            findTodoRepository
                .Setup(x => x.FindById(someTodoId))
                .Returns(new Domain.Todo.Update.Models.Todo(someTodoId, "some title", "a description"));
            const string updatedTitle = "updated title"; 
            var args = new TodoUpdatingArgs(id:someTodoId, title: updatedTitle, description: string.Empty);

            var result = service.Update(args);
            
            result.IsOk.ShouldBeTrue();
            updateTodoRepository
                .Verify(x => x.Update(It.Is<Domain.Todo.Update.Models.Todo>(y => 
                    y.Title == updatedTitle)));
        }
    }
}