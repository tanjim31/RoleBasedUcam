using AutoMapper;
using FluentValidation;
using MediatR;
using RoleBased.Model;
using RoleBased.Repository.Interface;
using RoleBased.Services.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Command;

public record CreateStudentInfoCommand(VMStudentInfo student) : IRequest<CommandResult<VMStudentInfo>>;

public class CreateStudentInfoCommandHandler : IRequestHandler<CreateStudentInfoCommand, CommandResult<VMStudentInfo>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IValidator<CreateStudentInfoCommand> _validator;
    private readonly IMapper _mapper;

    public CreateStudentInfoCommandHandler(IStudentRepository studentRepository, IValidator<CreateStudentInfoCommand> validator, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CommandResult<VMStudentInfo>> Handle(CreateStudentInfoCommand request, CancellationToken cancellationToken)
    {
        var validate = await _validator.ValidateAsync(request, cancellationToken);
        if (!validate.IsValid)
            throw new ValidationException(validate.Errors);
        var result = _mapper.Map<StudentInfo>(request.student);
        var student = await _studentRepository.InsertAsync(result);
        return student switch
        {
            null => new CommandResult<VMStudentInfo>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMStudentInfo>(student, CommandResultTypeEnum.Success)
        };

    }
}
