using System;
using Microsoft.AspNetCore.Mvc;

namespace TuduManayer.web.api.Todo.Update
{
    public class UpdateTodoController : Controller
    {
        [HttpPut("/api/todos")]
        public IActionResult Update(TodoUpdatingRequest todoUpdatingRequest)
        {
            throw new NotImplementedException();
        }
    }
}