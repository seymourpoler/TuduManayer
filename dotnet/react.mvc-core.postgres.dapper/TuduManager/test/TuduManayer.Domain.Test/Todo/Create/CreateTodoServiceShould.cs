using System.Linq;
using Shouldly;
using TuduManayer.Domain.Todo.Create;
using Xunit;
using TuduManayer.Domain.Test.Todo.Create;

namespace TuduManayer.Domain.Test.Todo.Create
{
    public class CreateTodoServiceShould
    {
        [Fact]
        public void return_error_when_title_is_null()
        {
            var service = new CreateTodoService();
            var args = new TodoCreationArgs(title: null, description: "description");
            
            var result = service.Create(args);

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.Required);
        }
        
        [Fact]
        public void return_error_when_title_is_empty()
        {
            var service = new CreateTodoService();
            var args = new TodoCreationArgs(title: string.Empty, description: "description");
            
            var result = service.Create(args);

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.Required);
        }
        
        [Fact]
        public void return_error_when_title_is_white_space()
        {
            var service = new CreateTodoService();
            var args = new TodoCreationArgs(title: " ", description: "description");
            
            var result = service.Create(args);

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.Required);
        }

        [Fact]
        public void return_error_when_title_has_more_characters()
        {
            var title = StringGenerator.Generate(257);
            var service = new CreateTodoService();
            var args = new TodoCreationArgs(title: title, description: "description");
            
            var result = service.Create(args);

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.InvalidLength);
        }
        
        [Fact]
        public void return_error_when_description_has_more_characters()
        {
            var description = StringGenerator.Generate(257);
            var service = new CreateTodoService();
            var args = new TodoCreationArgs(title: "a title", description: description);
            
            var result = service.Create(args);

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Description));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.InvalidLength);
        }
        
        [Fact]
        public void return_error_when_title_and_description_has_more_characters()
        {
            var invalidLengthText = StringGenerator.Generate(257);
            var service = new CreateTodoService();
            var args = new TodoCreationArgs(title: invalidLengthText, description: invalidLengthText);
            
            var result = service.Create(args);

            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.InvalidLength);
            result.Errors[1].FieldId.ShouldBe(nameof(args.Description));
            result.Errors[1].ErrorCode.ShouldBe(ErrorCodes.InvalidLength);
        }

        [Fact]
        public void return_error_when_title_has_more_than_maximum_number_of_characters()
        {
            
        }
    }
}