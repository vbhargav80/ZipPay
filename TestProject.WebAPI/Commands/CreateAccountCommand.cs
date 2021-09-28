using MediatR;
using TestProject.WebAPI.Responses;

namespace TestProject.WebAPI.Commands
{
    public class CreateAccountCommand : IRequest<AccountResponse>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
