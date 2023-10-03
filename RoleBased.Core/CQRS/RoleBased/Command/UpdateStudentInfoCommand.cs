﻿using AutoMapper;
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

public record UpdateStudentInfoCommand(string id, VMStudentInfo student) : IRequest<CommandResult<VMStudentInfo>>;

public class UpdateStudentInfoCommandHandler : IRequestHandler<UpdateStudentInfoCommand, CommandResult<VMStudentInfo>>
{
    private readonly IStudentRepository _studentrepository;
    private readonly IValidator<UpdateStudentInfoCommand> _validator;
    private readonly IMapper _mapper;



    public UpdateStudentInfoCommandHandler(IStudentRepository studentRepository, IValidator<UpdateStudentInfoCommand> validator, IMapper mapper)
    {
        _studentrepository = studentRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CommandResult<VMStudentInfo>> Handle(UpdateStudentInfoCommand request, CancellationToken cancellationToken)
    {
        var validator = await _validator.ValidateAsync(request, cancellationToken);
        if (!validator.IsValid)
            throw new ValidationException(validator.Errors);
        var data = _mapper.Map<StudentInfo>(request.student);
        var result = await _studentrepository.UpdateAsync(request.id, data);
        return result switch
        {
            null => new CommandResult<VMStudentInfo>(null, CommandResultTypeEnum.UnprocessableEntity),
            _ => new CommandResult<VMStudentInfo>(result, CommandResultTypeEnum.Success)
        };
    }
}
