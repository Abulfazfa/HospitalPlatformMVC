using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using HospitalPlatformMVC.Utility;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Service
{
    public class TestService : GenericService<Test>, ITestService
    {
        public TestService(IBaseService baseService) : base(baseService)
        {
        }
    }
}
