using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo.item.model.Data;
using todo.item.model.Model;
using Microsoft.EntityFrameworkCore;

namespace todo.item.main.Controllers.Queries
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {


        private readonly DBContext ctx;

        public TodoItemController(DBContext ctx)
        {
            this.ctx = ctx;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItem()
        {
            return await ctx.TodoItem.ToListAsync();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var todoItem = await ctx.TodoItem.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
    }
}