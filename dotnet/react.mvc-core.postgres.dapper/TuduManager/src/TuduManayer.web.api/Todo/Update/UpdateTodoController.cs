using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
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
            var args = new TodoUpdatingArgs(
                id: todoUpdatingRequest.Id,
                title: todoUpdatingRequest.Title,
                description: todoUpdatingRequest.Description);
            var updateResult = updateTodoService.Update(args);
            if (updateResult.IsOk)
            {
                throw new NotImplementedException(); 
            }

            return BadRequest(updateResult.Errors);

        }
    }
}