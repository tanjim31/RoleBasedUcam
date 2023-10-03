using FluentValidation;
using MediatR;
using RoleBased.Repository.Concrete;
using RoleBased.Repository.Interface;
using RoleBased.Services.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Query;
public record GetAllLoginDBByIdQuery : IRequest<QueryResult<VMLoginDB>>
{
    [JsonConstructor]
    public GetAllLoginDBByIdQuery(string id)
    {
        Id = id;
    }
    public string Id { get; set; }

    public class GetAllLoginDBByIdQueryHandler : IRequestHandler<GetAllLoginDBByIdQuery, QueryResult<VMLoginDB>>
    {
        private readonly ILoginDBRepository _loginDBRepository;
        private readonly IValidator<GetAllLoginDBByIdQuery> _validator;
        public GetAllLoginDBByIdQueryHandler(ILoginDBRepository loginDRepository, IValidator<GetAllLoginDBByIdQuery> validator)
        {
            _loginDBRepository = loginDRepository;
            _validator = validator;
        }
        public async Task<QueryResult<VMLoginDB>> Handle(GetAllLoginDBByIdQuery request, CancellationToken cancellationToken)
        {
            var validate = await _validator.ValidateAsync(request, cancellationToken);
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);
            var student = await _loginDBRepository.GetByIdAsync(request.Id);
            return student switch
            {
                null => new QueryResult<VMLoginDB>(null, QueryResultTypeEnum.NotFound),
                _ => new QueryResult<VMLoginDB>(student, QueryResultTypeEnum.Success)
            };


        }
    }



}



