using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Command.Validation
{
    public class CreateStudentInfoCommandValidation : AbstractValidator<CreateStudentInfoCommand>
    {
        public CreateStudentInfoCommandValidation()
        {
            RuleFor(x => x.student).NotEmpty();
        }
    }
}
