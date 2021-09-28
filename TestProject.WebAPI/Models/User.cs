using System.ComponentModel.DataAnnotations;

namespace TestProject.WebAPI.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public decimal MonthlySalary { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public decimal MonthlyExpense { get; set; }
    }
}
