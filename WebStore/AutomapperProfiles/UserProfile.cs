using AutoMapper;
using WebStore.Models.Core;
using WebStore.Models.ViewModels;

namespace WebStore.AutomapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<WebStoreUser, UserViewModel>()
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.UserName))
                .ReverseMap();

        }
    }
}
