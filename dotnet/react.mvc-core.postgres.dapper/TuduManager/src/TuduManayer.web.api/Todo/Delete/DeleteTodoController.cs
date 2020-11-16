using Microsoft.AspNetCore.Mvc;
using TuduManayer.Domain.Todo.Delete;

namespace TuduManayer.web.api.Todo.Delete
{
    public class DeleteTodoController : Controller
    {
        private readonly IDeleteTodoService service;

        public DeleteTodoController(IDeleteTodoService service)
        {
            this.service = service;
        }

        [HttpDelete("/api/todos/{todoId}")]
        public IActionResult Delete(int todoId)
        {
            var resultExecution = service.Delete(todoId);
            if (resultExecution.IsOk)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}