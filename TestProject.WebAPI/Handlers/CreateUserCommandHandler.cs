using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TestProject.WebAPI.Commands;
using TestProject.WebAPI.Data;
using TestProject.WebAPI.Responses;

namespace TestProject.WebAPI.Handlers
{
    public class CreateUserCommandHandler : BaseHandler, IRequestHandler<CreateUserCommand, UserResponse>
    {
        public CreateUserCommandHandler(ZipPayDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<UserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var existingUser = DbContext.Users.FirstOrDefault(
                x => x.EmailAddress.Equals(command.EmailAddress, StringComparison.OrdinalIgnoreCase)
                );

            if (existingUser != null)
            {
                return new UserResponse { Error = ErrorMessages.DuplicateEmail };
            }

            var user = Mapper.Map<Models.User>(command);
            DbContext.Users.Add(user);

            await DbContext.SaveChangesAsync(cancellationToken);

            var userResponse = Mapper.Map<UserResponse>(user);
            return userResponse;
        }
    }
}
