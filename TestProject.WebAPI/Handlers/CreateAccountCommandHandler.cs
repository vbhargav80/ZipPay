using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestProject.WebAPI.Commands;
using TestProject.WebAPI.Data;
using TestProject.WebAPI.Responses;

namespace TestProject.WebAPI.Handlers
{
    public class CreateAccountCommandHandler : BaseHandler, IRequestHandler<CreateAccountCommand, AccountResponse>
    {
        // TODO: In a real production app this could come from some sort of a configuration
        private const decimal CreditAllowed = 1000;

        public CreateAccountCommandHandler(ZipPayDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<AccountResponse> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(x => x.Id == command.UserId, cancellationToken: cancellationToken);
            if (user == null)
            {
                return new AccountResponse { Error = ErrorMessages.UserDoesNotExist };
            }

            var disposableIncome = user.MonthlySalary - user.MonthlyExpense;
            if (disposableIncome < CreditAllowed)
            {
                return new AccountResponse { Error = ErrorMessages.InsufficientDisposableIncome };
            }

            var account = Mapper.Map<Models.Account>(command);
            account.User = user;

            DbContext.Accounts.Add(account);

            await DbContext.SaveChangesAsync(cancellationToken);

            var accountResponse = Mapper.Map<AccountResponse>(account);
            return accountResponse;
        }
    }
}
