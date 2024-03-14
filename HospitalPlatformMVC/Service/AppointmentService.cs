using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using HospitalPlatformMVC.Utility;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IBaseService _baseService;
        public AppointmentService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateAppointmentsAsync(AppointmentDto appointmentDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = appointmentDto,
                Url = SD.HospitalAPIBase + "Appointment/post/"
            });
        }

        public async Task<ResponseDto?> DeleteAppointmentsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.HospitalAPIBase + "Appointment/delete/" + id
            });
        }

        public async Task<List<AppointmentDto>?> GetAllAppointmentsAsync()
        {
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.HospitalAPIBase + "Appointment/get/"
            });
            return JsonConvert.DeserializeObject<List<AppointmentDto>>(Convert.ToString(response.Result));
        }

        public async Task<AppointmentDto?> GetAppointmentByIdAsync(int id)
        {
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.HospitalAPIBase + "Appointment/get/" + id
            });
            return JsonConvert.DeserializeObject<AppointmentDto?>(Convert.ToString(response.Result));
        }

        public async Task<ResponseDto?> UpdateAppointmentsAsync(AppointmentDto appointmentDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = appointmentDto,
                Url = SD.HospitalAPIBase + "Appointment/put/"
            });
        }
    }
}
