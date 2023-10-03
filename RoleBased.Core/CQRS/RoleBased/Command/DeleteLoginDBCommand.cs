using AutoMapper;
using FluentValidation;
using MediatR;
using RoleBased.Repository.Interface;
using RoleBased.Services.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Command;
public record DeleteLoginDBCommand(string id) : IRequest<CommandResult<VMLoginDB>>;

public class DeleteLoginDBCommandHandler : IRequestHandler<DeleteLoginDBCommand, CommandResult<VMLoginDB>>
{
    private readonly ILoginDBRepository _loginDBRepository;
    private readonly IValidator<DeleteLoginDBCommand> _validator;
    private readonly IMapper _mapper;
    public DeleteLoginDBCommandHandler(ILoginDBRepository loginDBRepository, IValidator<DeleteLoginDBCommand> validator, IMapper mapper)
    {
        _loginDBRepository = loginDBRepository;
        _validator = validator;
        _mapper = mapper;
    }
    public async Task<CommandResult<VMLoginDB>> Handle(DeleteLoginDBCommand request, CancellationToken cancellationToken)
    {
        var validator = await _validator.ValidateAsync(request, cancellationToken);
        if (!validator.IsValid) throw new ValidationException(validator.Errors);
        var result = await _loginDBRepository.DeleteAsync(request.id);
        return result switch
        {
            null => new CommandResult<VMLoginDB>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMLoginDB>(result, CommandResultTypeEnum.Success)
        };
    }
}


