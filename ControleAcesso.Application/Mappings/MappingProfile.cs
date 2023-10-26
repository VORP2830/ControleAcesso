using ControleAcesso.Application.DTOs;
using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Application.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserRegistrationDTO>().ReverseMap();
            CreateMap<UserProfile, UserProfileDTO>().ReverseMap();
            CreateMap<Profile, ProfileDTO>().ReverseMap();
            CreateMap<FunctionalityProfile, FunctionalityProfileDTO>().ReverseMap();
            CreateMap<Functionality, FunctionalityDTO>().ReverseMap();
            CreateMap<Methods, MethodDTO>().ReverseMap();
            CreateMap<MenuOption, MenuOptionDTO>().ReverseMap();
        }
    }
}
