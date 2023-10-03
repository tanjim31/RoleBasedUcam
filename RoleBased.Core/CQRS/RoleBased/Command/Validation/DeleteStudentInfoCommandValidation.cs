using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Command.Validation
{
    public class DeleteStudentInfoCommandValidation : AbstractValidator<DeleteStudentInfoCommand>
    {
        public DeleteStudentInfoCommandValidation()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Id is Required");
        }
    }
}
