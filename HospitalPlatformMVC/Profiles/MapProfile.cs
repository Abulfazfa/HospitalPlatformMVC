using AutoMapper;
using HospitalPlatformMVC.Models;

namespace SoundSystemShop.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, RegisterDto>().ReverseMap();
        }
    }

}
 