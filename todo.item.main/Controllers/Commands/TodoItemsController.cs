using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo.item.main.MediatR.Commands;
using todo.item.model.Data;
using todo.item.model.Model;

namespace todo.item.main.Controllers.Commands
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TodoItemsController(IMediator madiator)
        {
            this.mediator = madiator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<TodoItem>> Create(CreateTodoItem request)
        {
            var todoItem = await mediator.Send(request);

            return todoItem;
        }

        [HttpPost("update")]
        public async Task<ActionResult<TodoItem>> Update(UpdateTodoItem request)
        {
            var todoItem = await mediator.Send(request);

            return todoItem;
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(DeleteTodoItem request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
