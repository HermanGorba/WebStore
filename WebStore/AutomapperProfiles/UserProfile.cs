using AutoMapper;
using WebStore.Models.Core;
using WebStore.Models.DTOs;
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

            CreateMap<WebStoreUser, UserDetailsViewModel>()
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.UserName))
                .ReverseMap();

            CreateMap<CreateUserDTO, WebStoreUser>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Login));

            CreateMap<EditUserDTO, WebStoreUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Login))
                .ReverseMap();

            CreateMap<WebStoreUser, ChangePasswordDTO>();

            CreateMap<RegisterViewModel, WebStoreUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Login));
        }
    }
}
