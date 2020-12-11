using System;
using Microsoft.AspNetCore.Mvc;
using TuduManayer.Domain.Todo.FindById;

namespace TuduManayer.web.api.Todo.Update
{
    public class FindByTodoIdController : Controller
    {
        private readonly IFindByTodoIdService findByTodoIdService;

        public FindByTodoIdController(IFindByTodoIdService findByTodoIdService)
        {
            this.findByTodoIdService = findByTodoIdService;
        }

        [HttpGet("/api/todos/{todoId}")]
        public IActionResult Find(int todoId)
        {
            var serviceExecutionResult = findByTodoIdService.Find(todoId);
            if (serviceExecutionResult.IsOk)
            {
                var todo = findByTodoIdService.Find(todoId);
                return Ok(todo.Model);
            }
            return new NotFoundResult();
        }
    }
}