using System.Linq;
using Shouldly;
using TuduManayer.Domain.Todo.Create;
using Xunit;

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
    }
}