using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using HospitalPlatformMVC.Utility;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Service
{
    public class UserService : GenericService<UserDto>, IUserService
    {
        public UserService(IBaseService baseService) : base(baseService)
        {
        }
    }
}
