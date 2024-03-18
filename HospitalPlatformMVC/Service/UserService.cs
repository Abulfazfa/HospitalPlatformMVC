using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using HospitalPlatformMVC.Utility;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Service
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(IBaseService baseService) : base(baseService)
        {
        }
    }
}
