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
    public class TodoItemHandler
        : IRequestHandler<CreateTodoItem, TodoItem>
        , IRequestHandler<UpdateTodoItem, TodoItem>
        , IRequestHandler<DeleteTodoItem>
    {
        private readonly DBContext ctx;

        public TodoItemHandler(DBContext ctx)
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
