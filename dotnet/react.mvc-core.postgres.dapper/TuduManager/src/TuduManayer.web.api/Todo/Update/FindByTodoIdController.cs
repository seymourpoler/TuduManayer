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
        public IActionResult Find([FromQuery] int todoId)
        {
            throw new NotImplementedException();
        }
    }
}