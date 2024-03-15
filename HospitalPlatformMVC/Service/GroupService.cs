using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using HospitalPlatformMVC.Utility;
using Newtonsoft.Json;

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
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = departmentDto,
                Url = SD.HospitalAPIBase + "Group/post/"
            });
            return response;
        }

        public async Task<ResponseDto?> DeleteDepartmentsAsync(int id)
        {
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.HospitalAPIBase + "Group/delete/" + id
            });
            return response;
        }

        public async Task<List<DepartmentDto>?> GetAllDepartmentsAsync()
        {
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.HospitalAPIBase + "Group/get/"
            });
            return JsonConvert.DeserializeObject<List<DepartmentDto>?>(Convert.ToString(response.Result));
        }

        public async Task<DepartmentDto?> GetDepartmentByIdAsync(int id)
        {
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.HospitalAPIBase + "Group/get/" + id
            });
            return JsonConvert.DeserializeObject<DepartmentDto?>(Convert.ToString(response.Result));
        }

        public async Task<ResponseDto?> UpdateDepartmentsAsync(DepartmentDto departmentDto)
        {
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = departmentDto,
                Url = SD.HospitalAPIBase + "Group/put/"
            });
            return response;
        }
    }
}
