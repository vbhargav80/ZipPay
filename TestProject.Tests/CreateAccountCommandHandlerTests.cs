using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using TestProject.WebAPI;
using TestProject.WebAPI.Commands;
using TestProject.WebAPI.Handlers;
using TestProject.WebAPI.Responses;
using Xunit;

namespace TestProject.Tests
{
    public class CreateAccountCommandHandlerTests : TestBase
    {
        private readonly IRequestHandler<CreateAccountCommand, AccountResponse> _requestHandler;
        private readonly IRequestHandler<CreateUserCommand, UserResponse> _userRequestHandler;

        public CreateAccountCommandHandlerTests()
        {
            _requestHandler = new CreateAccountCommandHandler(DbContext, Mapper);
            _userRequestHandler = new CreateUserCommandHandler(DbContext, Mapper);
        }

        [Fact(DisplayName = "Should not create account if the user has insufficient disposable income")]
        public async Task ShouldNotCreateAccountIfUserHasInsufficientDisposableIncome()
        {
            var createUserCommand = new CreateUserCommand
            {
                EmailAddress = TestData.MockEmailAddress,
                MonthlySalary = 1500,
                MonthlyExpense = 500.01m,
                Name = TestData.MockName
            };

            var userResponse = await _userRequestHandler.Handle(createUserCommand, CancellationToken.None);

            userResponse.Should().NotBeNull();
            userResponse.Id.Should().BeGreaterThan(0);


            var createAccountCommand = new CreateAccountCommand
            {
                Name = "Test Account 1",
                UserId = userResponse.Id
            };

            var accountResponse = await _requestHandler.Handle(createAccountCommand, CancellationToken.None);

            accountResponse.Should().NotBeNull();
            accountResponse.Successful.Should().BeFalse();
            accountResponse.Error.Should().Be(ErrorMessages.InsufficientDisposableIncome);
        }

        [Fact(DisplayName = "Should create account if the user has sufficient disposable income")]
        public async Task ShouldCreateAccountIfUserHasSufficientDisposableIncome()
        {
            var createUserCommand = new CreateUserCommand
            {
                EmailAddress = TestData.MockEmailAddress2,
                MonthlySalary = 1500,
                MonthlyExpense = 500,
                Name = TestData.MockName
            };

            var userResponse = await _userRequestHandler.Handle(createUserCommand, CancellationToken.None);

            userResponse.Should().NotBeNull();
            userResponse.Id.Should().BeGreaterThan(0);

            var createAccountCommand = new CreateAccountCommand
            {
                Name = "Test Account 1",
                UserId = userResponse.Id
            };

            var accountResponse = await _requestHandler.Handle(createAccountCommand, CancellationToken.None);

            accountResponse.Should().NotBeNull();
            accountResponse.Successful.Should().BeTrue();
            accountResponse.UserId.Should().Be(userResponse.Id);
            accountResponse.Id.Should().BeGreaterThan(0);
        }
    }
}
