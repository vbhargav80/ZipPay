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
    public class GetAllUsersQueryHandler : BaseHandler, IRequestHandler<GetAllUsersQuery, List<UserResponse>>
    {
        public GetAllUsersQueryHandler(ZipPayDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<List<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await DbContext.Users.ToListAsync(cancellationToken: cancellationToken);
            if (users == null || !users.Any())
                return new List<UserResponse>();

            return users.Select(x => Mapper.Map<UserResponse>(x)).ToList();
        }
    }
}
