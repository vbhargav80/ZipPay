using System.Text.Json.Serialization;

namespace TestProject.WebAPI.Responses
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public string Error { get; set; }
        [JsonIgnore]
        public bool Successful => string.IsNullOrEmpty(Error);
    }
}
