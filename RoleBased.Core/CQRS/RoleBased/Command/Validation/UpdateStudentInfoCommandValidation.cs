using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Command.Validation
{
    public class UpdateStudentInfoCommandValidation : AbstractValidator<UpdateStudentInfoCommand>
    {
        public UpdateStudentInfoCommandValidation()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Id is Requered");
        }
    }
}
