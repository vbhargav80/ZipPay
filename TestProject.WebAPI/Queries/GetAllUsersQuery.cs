using System.Collections.Generic;
using MediatR;
using TestProject.WebAPI.Responses;

namespace TestProject.WebAPI.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserResponse>>
    {
    }
}
