using System.ComponentModel.DataAnnotations;
using MediatR;
using TestProject.WebAPI.Responses;

namespace TestProject.WebAPI.Commands
{
    public class CreateUserCommand : IRequest<UserResponse>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public decimal MonthlySalary { get; set; }
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public decimal MonthlyExpense { get; set; }
    }
}
