using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using HospitalPlatformMVC.Utility;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HospitalPlatformMVC.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IBaseService _baseService;
        public DoctorService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateDoctorsAsync(DoctorDto doctorDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = doctorDto,
                Url = SD.HospitalAPIBase + "Doctor/post/"
            });
        }

        public async Task<ResponseDto?> DeleteDoctorsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.HospitalAPIBase + "Doctor/delete/" + id
            });
        }

        public async Task<List<DoctorDto>?> GetAllDoctorsAsync()
        {
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.HospitalAPIBase + "Doctor/get/"
            });
           
            return JsonConvert.DeserializeObject<List<DoctorDto>>(Convert.ToString(response.Result));
        }

        public async Task<DoctorDto?> GetDoctorByIdAsync(int id)
        {
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.HospitalAPIBase + "Doctor/get/" + id
            });
            return JsonConvert.DeserializeObject<DoctorDto>(Convert.ToString(response.Result));
        }

        public async Task<ResponseDto?> UpdateDoctorsAsync(DoctorDto doctorDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = doctorDto,
                Url = SD.HospitalAPIBase + "Doctor/put/"
            });
        }
    }
}
