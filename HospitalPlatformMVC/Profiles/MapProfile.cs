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


    class car
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
    }

	class masin
	{
		public int id { get; set; }
		public string username { get; set; }
	}


}
