using MediatR;
using TestProject.WebAPI.Responses;

namespace TestProject.WebAPI.Queries
{
    public class GetUserQuery : IRequest<UserResponse>
    {
        public int Id { get; set; }
    }
}
