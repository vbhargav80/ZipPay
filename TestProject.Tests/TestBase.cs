using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestProject.WebAPI.Data;
using TestProject.WebAPI.Mapping;

namespace TestProject.Tests
{
    public class TestBase
    {
        protected ZipPayDBContext DbContext;
        protected IMapper Mapper;

        public TestBase()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ZipPayDBContext>()
                .UseInMemoryDatabase(databaseName: "ZipPayTests")
                .Options;

            DbContext = new ZipPayDBContext(dbContextOptions);

            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new UserProfile());
            });
            Mapper = config.CreateMapper();
        }

        public void ClearDatabase()
        {
            foreach (var customer in DbContext.Users)
            {
                DbContext.Users.Remove(customer);
            }

            DbContext.SaveChanges();
        }
    }
}
