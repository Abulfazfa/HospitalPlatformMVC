using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using HospitalPlatformMVC.Utility;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HospitalPlatformMVC.Service
{
    public class DoctorService : GenericService<DoctorDto>, IDoctorService
    {
        public DoctorService(IBaseService baseService) : base(baseService)
        {
        }
    }
}
