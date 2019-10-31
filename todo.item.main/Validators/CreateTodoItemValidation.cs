using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo.item.main.MediatR.Commands;
using todo.item.model.Model;

namespace todo.item.main.Validators
{
    public class CreateTodoItemValidation : AbstractValidator<CreateTodoItem>
    {
        public CreateTodoItemValidation()
        {
            RuleFor(t => t.Title).NotEmpty().Length(1, 30);
            RuleFor(t => t.Description).Length(0, 200);
            RuleFor(t => t.Deadline).NotEmpty();
        }
    }
}
