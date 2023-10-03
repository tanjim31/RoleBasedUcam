using FluentValidation;
using MediatR;
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

public record GetAllStudentInfoByIdQuery : IRequest<QueryResult<VMStudentInfo>>
{
    [JsonConstructor]
    public GetAllStudentInfoByIdQuery(string id)
    {
        Id = id;
    }
    public string Id { get; set; }

    public class GetAllStudentInfoByIdQueryHandler : IRequestHandler<GetAllStudentInfoByIdQuery, QueryResult<VMStudentInfo>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IValidator<GetAllStudentInfoByIdQuery> _validator;
        public GetAllStudentInfoByIdQueryHandler(IStudentRepository studentRepository, IValidator<GetAllStudentInfoByIdQuery> validator)
        {
            _studentRepository = studentRepository;
            _validator = validator;
        }
        public async Task<QueryResult<VMStudentInfo>> Handle(GetAllStudentInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var validate = await _validator.ValidateAsync(request, cancellationToken);
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);
            var student = await _studentRepository.GetByIdAsync(request.Id);
            return student switch
            {
                null => new QueryResult<VMStudentInfo>(null, QueryResultTypeEnum.NotFound),
                _ => new QueryResult<VMStudentInfo>(student, QueryResultTypeEnum.Success)
            };


        }
    }



}
