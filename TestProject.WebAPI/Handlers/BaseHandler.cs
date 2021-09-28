using AutoMapper;
using TestProject.WebAPI.Data;

namespace TestProject.WebAPI.Handlers
{
    public abstract class BaseHandler
    {
        protected readonly ZipPayDBContext DbContext;
        protected readonly IMapper Mapper;

        protected BaseHandler(ZipPayDBContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }
    }
}
