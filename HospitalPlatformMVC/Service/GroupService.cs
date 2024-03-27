using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using HospitalPlatformMVC.Utility;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Service
{
    public class GroupService : GenericService<Group>, IGroupService
    {
        public GroupService(IBaseService baseService) : base(baseService)
        {
        }
    }
}
