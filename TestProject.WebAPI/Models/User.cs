using System.Collections.Generic;

namespace TestProject.WebAPI.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal MonthlyExpense { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
