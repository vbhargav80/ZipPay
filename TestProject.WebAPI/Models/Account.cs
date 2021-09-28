namespace TestProject.WebAPI.Models
{
    public class Account : Entity
    {
        public string Name { get; set; }
        public User User { get; set; }
    }
}
