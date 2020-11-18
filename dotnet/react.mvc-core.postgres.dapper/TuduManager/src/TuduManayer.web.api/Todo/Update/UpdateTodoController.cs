using Microsoft.AspNetCore.Mvc;
using TuduManayer.Domain;
using TuduManayer.Domain.Todo;

namespace TuduManayer.web.api.Todo.Update
{
    public class UpdateTodoController : Controller
    {
        private readonly IUpdateTodoService updateTodoService;

        public UpdateTodoController(IUpdateTodoService updateTodoService)
        {
            this.updateTodoService = updateTodoService;
        }

        [HttpPut("/api/todos")]
        public IActionResult Update(TodoUpdatingRequest todoUpdatingRequest)
        {
            var updateResult = UpdateTodo(todoUpdatingRequest);
            if (updateResult.IsOk) return Ok();

            return BadRequest(updateResult.Errors);
        }

        private ServiceExecutionResult UpdateTodo(TodoUpdatingRequest todoUpdatingRequest)
        {
            var args = new TodoUpdatingArgs(
                todoUpdatingRequest.Id,
                todoUpdatingRequest.Title,
                todoUpdatingRequest.Description);
            return updateTodoService.Update(args);
        }
    }
}