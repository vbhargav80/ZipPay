using System.Collections.Generic;
using MediatR;
using TestProject.WebAPI.Responses;

namespace TestProject.WebAPI.Queries
{
    public class GetAccountQuery : IRequest<AccountResponse>, IRequest<List<AccountResponse>>
    {
        public int Id { get; set; }
    }
}
