using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo.item.main.MediatR.Commands
{
    public class DeleteTodoItem : IRequest
    {
        public int Id { get; set; }
    }
}
