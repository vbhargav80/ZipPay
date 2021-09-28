using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class CreateUserCommandHandlerTests : TestBase
    {
        private readonly IRequestHandler<CreateUserCommand, UserResponse> _requestHandler;

        public CreateUserCommandHandlerTests()
        {
            _requestHandler = new CreateUserCommandHandler(DbContext, Mapper);
        }

        [Fact(DisplayName = "Should not allow more than one user with the same email address")]
        public async Task ShouldNotAllowMoreThanOneUserWithSameEmailAddress()
        {
            var createUserCommand = new CreateUserCommand
            {
                EmailAddress = TestData.MockEmailAddress,
                MonthlyExpense = 1850.04m,
                MonthlySalary = 1855m,
                Name = TestData.MockName
            };

            var response = await _requestHandler.Handle(createUserCommand, CancellationToken.None);

            response.Should().NotBeNull();

            response.Id.Should().BeGreaterThan(0);
            response.Name.Should().Be(TestData.MockName);
            response.EmailAddress.Should().Be(TestData.MockEmailAddress);
            response.Successful.Should().BeTrue();

            // Now create a duplicate record with the same email address
            createUserCommand.Name = $"Duplicate {createUserCommand.Name}";
            var duplicateResponse = await _requestHandler.Handle(createUserCommand, CancellationToken.None);

            duplicateResponse.Should().NotBeNull();
            duplicateResponse.Successful.Should().BeFalse();
            duplicateResponse.Error.Should().Be(ErrorMessages.DuplicateEmail);
        }
    }
}
