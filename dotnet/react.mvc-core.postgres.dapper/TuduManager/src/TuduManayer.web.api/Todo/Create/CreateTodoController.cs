using System;
using Microsoft.AspNetCore.Mvc;
using TuduManayer.Domain.Todo.Create;

namespace TuduManayer.web.api.Todo.Create
{
    public class CreateTodoController : Controller
    {
        private readonly ICreateTodoService createTodoService;

        public CreateTodoController(ICreateTodoService createTodoService)
        {
            this.createTodoService = createTodoService;
        }
        
        [HttpPost("/api/todos")]
        public IActionResult Create(TodoCreationRequest todoCreationRequest)
        {
            var args = new TodoCreationArgs(todoCreationRequest.Title, todoCreationRequest.Description);
            var response = createTodoService.Create(args);
            if(response.IsOk){
                throw new NotImplementedException();
            }

            return BadRequest(response.Errors);
        }
    }
}