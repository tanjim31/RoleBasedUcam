using MediatR;
using RoleBased.Repository.Concrete;
using RoleBased.Repository.Interface;
using RoleBased.Services.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Query;

public record GetAllStudentInfoQuery() : IRequest<QueryResult<IEnumerable<VMStudentInfo>>>;

public class GetAllStudentInfoQueryHandler : IRequestHandler<GetAllStudentInfoQuery, QueryResult<IEnumerable<VMStudentInfo>>>
{
    private readonly IStudentRepository _studentInfoRepository;
    public GetAllStudentInfoQueryHandler(IStudentRepository studentInfoRepository)
    {
        _studentInfoRepository = studentInfoRepository;
    }
    public async Task<QueryResult<IEnumerable<VMStudentInfo>>> Handle(GetAllStudentInfoQuery request, CancellationToken cancellationToken)
    {
        var studentinfo = await _studentInfoRepository.GetAllAsync();
        return studentinfo switch
        {
            null => new QueryResult<IEnumerable<VMStudentInfo>>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<IEnumerable<VMStudentInfo>>(studentinfo, QueryResultTypeEnum.Success)
        };
    }
}
