using System.Linq;
using Shouldly;
using TuduManayer.Domain.Todo;
using Xunit;

namespace TuduManayer.Domain.Test.Todo.Update
{
    public class UpdateTodoShould
    {
        [Fact]
        public void return_error_when_title_is_null()
        {
            var service = new UpdateTodoService();
            var args = new TodoUpdatingArgs(id:1, title: null, description: "a description");

            var result = service.Update(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.Required);
        }
        
        [Fact]
        public void return_error_when_title_is_string_empty()
        {
            var service = new UpdateTodoService();
            var args = new TodoUpdatingArgs(id:1, title: string.Empty, description: "a description");

            var result = service.Update(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.Required);
        }
        
        [Fact]
        public void return_error_when_title_is_white_space()
        {
            var service = new UpdateTodoService();
            var args = new TodoUpdatingArgs(id:1, title: "  ", description: "a description");

            var result = service.Update(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors.First().FieldId.ShouldBe(nameof(args.Title));
            result.Errors.First().ErrorCode.ShouldBe(ErrorCodes.Required);
        }
    }
}