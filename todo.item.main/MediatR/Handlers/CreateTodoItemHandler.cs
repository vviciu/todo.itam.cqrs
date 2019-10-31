using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using todo.item.main.MediatR.Commands;
using todo.item.model.Data;
using todo.item.model.Model;

namespace todo.item.main.MediatR.Handlers
{
    public class CreateTodoItemHandler : IRequestHandler<CreateTodoItem, TodoItem>
    {
        private readonly DBContext ctx;

        public CreateTodoItemHandler(DBContext ctx)
        {
            this.ctx = ctx;
        }


        public async Task<TodoItem> Handle(CreateTodoItem request, CancellationToken cancellationToken)
        {
            var todoItem = new TodoItem
            {
                Title = request.Title,
                Deadline = request.Deadline,
                Description = request.Description
            };
            ctx.Add(todoItem);

            await ctx.SaveChangesAsync();

            return todoItem;
        }
    }
}
