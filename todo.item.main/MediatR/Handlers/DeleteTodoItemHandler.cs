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
    public class DeleteTodoItemHandler : IRequestHandler<DeleteTodoItem>
    {
        private readonly DBContext ctx;

        public DeleteTodoItemHandler(DBContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<Unit> Handle(DeleteTodoItem request, CancellationToken cancellationToken)
        {
            var todoItem = ctx.TodoItem.FirstOrDefault(v => v.Id == request.Id);
            if (todoItem == null)
            {
                throw new Exception("Record does not exist");
            }
            ctx.TodoItem.Remove(todoItem);
            await ctx.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
