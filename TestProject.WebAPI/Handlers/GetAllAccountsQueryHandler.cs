using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestProject.WebAPI.Data;
using TestProject.WebAPI.Queries;
using TestProject.WebAPI.Responses;

namespace TestProject.WebAPI.Handlers
{
    public class GetAllAccountsQueryHandler : BaseHandler, IRequestHandler<GetAllAccountsQuery, List<AccountResponse>>
    {
        public GetAllAccountsQueryHandler(ZipPayDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<List<AccountResponse>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var accounts = await DbContext.Accounts.Include(a => a.User).ToListAsync(cancellationToken: cancellationToken);
            if (accounts == null || !accounts.Any())
                return new List<AccountResponse>();

            return accounts.Select(x => Mapper.Map<AccountResponse>(x)).ToList();
        }
    }
}
