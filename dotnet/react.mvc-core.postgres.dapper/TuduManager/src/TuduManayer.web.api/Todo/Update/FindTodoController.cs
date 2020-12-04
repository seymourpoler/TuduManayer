using System;
using Microsoft.AspNetCore.Mvc;

namespace TuduManayer.web.api.Todo.Update
{
    public class FindTodoController : Controller
    {
        [HttpGet("/api/todos/{todoId}")]
        public IActionResult Find([FromQuery] int todoId)
        {
            throw new NotImplementedException();
        }
    }
}