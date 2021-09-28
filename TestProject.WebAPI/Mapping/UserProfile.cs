using AutoMapper;
using TestProject.WebAPI.Commands;
using TestProject.WebAPI.Models;
using TestProject.WebAPI.Responses;

namespace TestProject.WebAPI.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<CreateUserCommand, User>();
        }
    }
}
