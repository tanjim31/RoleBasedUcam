using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Command.Validation
{
    public class UpdateLoginDBCommandValidation : AbstractValidator<UpdateLoginDBCommand>
    {
        public UpdateLoginDBCommandValidation()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Id is Requered");
        }
    }
}
