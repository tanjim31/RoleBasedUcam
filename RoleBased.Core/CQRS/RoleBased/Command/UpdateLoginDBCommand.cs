using AutoMapper;
using FluentValidation;
using MediatR;
using RoleBased.Model;
using RoleBased.Repository.Concrete;
using RoleBased.Repository.Interface;
using RoleBased.Services.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Command;

public record UpdateLoginDBCommand(string id, VMLoginDB login) : IRequest<CommandResult<VMLoginDB>>;

public class UpdateLoginDBCommandHandler : IRequestHandler<UpdateLoginDBCommand, CommandResult<VMLoginDB>>
{
    private readonly ILoginDBRepository _loginDBRepository;
    private readonly IValidator<UpdateLoginDBCommand> _validator;
    private readonly IMapper _mapper;



    public UpdateLoginDBCommandHandler(ILoginDBRepository loginDBRepository, IValidator<UpdateLoginDBCommand> validator, IMapper mapper)
    {
        _loginDBRepository = loginDBRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CommandResult<VMLoginDB>> Handle(UpdateLoginDBCommand request, CancellationToken cancellationToken)
    {
        var validator = await _validator.ValidateAsync(request, cancellationToken);
        if (!validator.IsValid)
            throw new ValidationException(validator.Errors);
        var data = _mapper.Map<LoginDB>(request.login);
        var result = await _loginDBRepository.UpdateAsync(request.id, data);            //
        return result switch
        {
            null => new CommandResult<VMLoginDB>(null, CommandResultTypeEnum.UnprocessableEntity),
            _ => new CommandResult<VMLoginDB>(result, CommandResultTypeEnum.Success)
        };
    }
}

