using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;

namespace HospitalPlatformMVC.Service
{
    public class OfficeService : GenericService<Office>, IOfficeService
    {
        public OfficeService(IBaseService baseService) : base(baseService)
        {
        }
    }
}
