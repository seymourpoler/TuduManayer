using System.Linq;
using Moq;
using Shouldly;
using TuduManayer.Domain.Todo.Create;
using TuduManayer.Domain.Todo.Validation;
using Xunit;

namespace TuduManayer.Domain.Test.Todo.Create
{
    public class CreateTodoServiceShould
    {
        private int MoreThanMaximumNumberOfCharacters = Validator.MaximumNumberOfCharacters + 1;
        private ICreateTodoService service;
        private Mock<ISaveTodoRepository> repository;
        
        public CreateTodoServiceShould()
        {
            repository = new Mock<ISaveTodoRepository>();
            service = new CreateTodoService(repository.Object, new Validator());
        }

        [Fact]
        public void return_error_when_title_is_null()
        {
            var args = new TodoCreationArgs(title: null, description: "description");
            
            var result = service.Create(args);

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.Required);
        }
        
        [Fact]
        public void return_error_when_title_is_empty()
        {
            var args = new TodoCreationArgs(title: string.Empty, description: "description");
            
            var result = service.Create(args);

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.Required);
        }
        
        [Fact]
        public void return_error_when_title_is_white_space()
        {
            var args = new TodoCreationArgs(title: " ", description: "description");
            
            var result = service.Create(args);

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.Required);
        }

        [Fact]
        public void return_error_when_title_has_more_characters()
        {
            var title = StringGenerator.Generate(MoreThanMaximumNumberOfCharacters);
            var args = new TodoCreationArgs(title: title, description: null);
            
            var result = service.Create(args);

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.InvalidLength);
        }
        
        [Fact]
        public void return_error_when_description_has_more_characters()
        {
            var description = StringGenerator.Generate(MoreThanMaximumNumberOfCharacters);
            var args = new TodoCreationArgs(title: "a title", description: description);
            
            var result = service.Create(args);

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Description));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.InvalidLength);
        }
        
        [Fact]
        public void return_error_when_title_is_string_empty_and_description_has_more_characters()
        {
            var invalidLengthText = StringGenerator.Generate(MoreThanMaximumNumberOfCharacters);
            var args = new TodoCreationArgs(title: string.Empty, description: invalidLengthText);
            
            var result = service.Create(args);

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.Required);
            result.Errors.Second().FieldId.ShouldBe(nameof(args.Description));
            result.Errors.Second().ErrorCode.ShouldBe(ErrorCodes.InvalidLength);
        }

        [Fact]
        public void create_todo()
        {
            const string title = "some title";
            var args = new TodoCreationArgs(title: title, description: "some description");
            
            var result = service.Create(args);

            result.IsOk.ShouldBeTrue();
            repository.Verify(x => x.Save(It.Is<Domain.Todo.Create.Models.Todo>(y => y.Title == title)));
        }
    }
}