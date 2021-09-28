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
    public class GetAccountQueryHandler : BaseHandler, IRequestHandler<GetAccountQuery, AccountResponse>
    {
        public GetAccountQueryHandler(ZipPayDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<AccountResponse> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            var account = await DbContext.Accounts.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (account == null)
                return null;

            var accountResponse = Mapper.Map<AccountResponse>(account);

            return accountResponse;
        }
    }
}
