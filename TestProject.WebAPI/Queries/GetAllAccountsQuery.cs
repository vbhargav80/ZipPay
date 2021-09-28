using System.Collections.Generic;
using MediatR;
using TestProject.WebAPI.Models;
using TestProject.WebAPI.Responses;

namespace TestProject.WebAPI.Queries
{
    public class GetAllAccountsQuery : IRequest<List<AccountResponse>>
    {
    }
}
