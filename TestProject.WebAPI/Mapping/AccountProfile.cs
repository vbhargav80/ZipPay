using AutoMapper;
using TestProject.WebAPI.Commands;
using TestProject.WebAPI.Models;
using TestProject.WebAPI.Responses;

namespace TestProject.WebAPI.Mapping
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountResponse>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.User.Id))
                ;

            CreateMap<CreateAccountCommand, Account>();
        }
    }
}
