using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo.item.model.Model;

namespace todo.item.main.MediatR.Commands
{
    public class UpdateTodoItem : IRequest<TodoItem>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
    }
}
