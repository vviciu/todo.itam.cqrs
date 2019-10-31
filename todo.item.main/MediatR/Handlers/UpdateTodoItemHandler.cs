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
    public class UpdateTodoItemHandler : IRequestHandler<UpdateTodoItem, TodoItem>
    {

        private readonly DBContext ctx;

        public UpdateTodoItemHandler(DBContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<TodoItem> Handle(UpdateTodoItem request, CancellationToken cancellationToken)
        {
            var todoItem = ctx.TodoItem.FirstOrDefault(v => v.Id == request.Id);
            if (todoItem == null)
            {
                throw new Exception("Record does not exist");
            }
            todoItem.Title = request.Title;
            todoItem.Deadline = request.Deadline;
            ctx.TodoItem.Update(todoItem);
            await ctx.SaveChangesAsync();
            return todoItem;
        }
    }
}
