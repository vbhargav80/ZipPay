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
    public class GetUserQueryHandler : BaseHandler, IRequestHandler<GetUserQuery, UserResponse>
    {
        public GetUserQueryHandler(ZipPayDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await DbContext.Users.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (user == null)
                return null;

            var userResponse = Mapper.Map<UserResponse>(user);

            return userResponse;
        }
    }
}
