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
public record GetAllLoginDBQuery() : IRequest<QueryResult<IEnumerable<VMLoginDB>>>;

public class GetAllLoginDBQueryHandler : IRequestHandler<GetAllLoginDBQuery, QueryResult<IEnumerable<VMLoginDB>>>
{
    private readonly ILoginDBRepository _loginDBRepository;
    public GetAllLoginDBQueryHandler(ILoginDBRepository loginDBRepository)
    {
        _loginDBRepository = loginDBRepository;
    }
    public async Task<QueryResult<IEnumerable<VMLoginDB>>> Handle(GetAllLoginDBQuery request, CancellationToken cancellationToken)
    {
        var loginDB = await _loginDBRepository.GetAllAsync();
        return loginDB switch
        {
            null => new QueryResult<IEnumerable<VMLoginDB>>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<IEnumerable<VMLoginDB>>(loginDB, QueryResultTypeEnum.Success)
        };
    }
}


