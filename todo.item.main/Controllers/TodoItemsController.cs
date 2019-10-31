using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Octokit;
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
        private readonly DBContext ctx;
        private readonly IValidator<CreateTodoItem> createTodoItemValidator;
        private readonly IValidator<UpdateTodoItem> updateTodoItemValidator;

        public TodoItemsController(IMediator madiator, DBContext ctx, IValidator<CreateTodoItem> createTodoItemValidator, IValidator<UpdateTodoItem> updateTodoItemValidator)
        {
            this.mediator = madiator;
            this.ctx = ctx;
            this.createTodoItemValidator = createTodoItemValidator;
            this.updateTodoItemValidator = updateTodoItemValidator;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Get()
        {
            return await ctx.TodoItem.ToListAsync();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            var todoItem = await ctx.TodoItem.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPost("Post")]
        public async Task<ActionResult<TodoItem>> Post(CreateTodoItem request)
        {
            var validationResult = createTodoItemValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var todoItem = await mediator.Send(request);

            return todoItem;
        }

        [HttpPost("Put")]
        public async Task<ActionResult<TodoItem>> Put(UpdateTodoItem request)
        {
            var validationResult = updateTodoItemValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

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
