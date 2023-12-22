using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using HospitalPlatformMVC.Utility;

namespace HospitalPlatformMVC.Service
{
    public class GroupService : IGroupService
    {
        private readonly IBaseService _baseService;
        public GroupService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateDepartmentsAsync(DepartmentDto departmentDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = departmentDto,
                Url = SD.HospitalAPIBase + "Group/post/"
            });
        }

        public async Task<ResponseDto?> DeleteDepartmentsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.HospitalAPIBase + "Group/delete/" + id
            });
        }

        public async Task<ResponseDto?> GetAllDepartmentsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.HospitalAPIBase + "Group/get/"
            });
        }

        public async Task<ResponseDto?> GetDepartmentByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.HospitalAPIBase + "Group/get/" + id
            });
        }

        public async Task<ResponseDto?> UpdateDepartmentsAsync(DepartmentDto departmentDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = departmentDto,
                Url = SD.HospitalAPIBase + "Group/put/"
            });
        }
    }
}
