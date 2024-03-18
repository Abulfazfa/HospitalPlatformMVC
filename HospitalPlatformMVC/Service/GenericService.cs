using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using HospitalPlatformMVC.Utility;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Service
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IBaseService _baseService;

        public GenericService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateAsync(T t)
        {
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = t,
                Url = SD.HospitalAPIBase + $"{typeof(T).Name}/post/"
            });
            return response;
        }

        public async Task<ResponseDto?> DeleteAsync(int id)
        {
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.HospitalAPIBase + $"{typeof(T).Name}/delete/" + id
            });
            return response;
        }
    
        public async Task<List<T>?> GetAllAsync()
        {
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.HospitalAPIBase + $"{typeof(T).Name}/get/"
            });
            return JsonConvert.DeserializeObject<List<T>>(Convert.ToString(response.Result));
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.HospitalAPIBase + $"{typeof(T).Name}/get/" + id
            });
            return JsonConvert.DeserializeObject<T>(Convert.ToString(response.Result));
        }

        public async Task<ResponseDto?> UpdateAsync(T t)
        {
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = t,
                Url = SD.HospitalAPIBase + $"{typeof(T).Name}/put/"
            });
            return response;
        }
    }
}
