using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Data
{
    public class ZipPayDBContext : DbContext
    {
        public ZipPayDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
