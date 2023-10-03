using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Query.Validation
{
    public class GetAllStudentInfoByIdQueryValidation : AbstractValidator<GetAllStudentInfoByIdQuery>
    {
        public GetAllStudentInfoByIdQueryValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Required");
        }
    }
}
