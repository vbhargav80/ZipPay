using System.Text.Json.Serialization;

namespace TestProject.WebAPI.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal MonthlyExpense { get; set; }
        [JsonIgnore]
        public string Error { get; set; }
        [JsonIgnore]
        public bool Successful => string.IsNullOrEmpty(Error);
    }
}
