using HospitalPlatformMVC.Models;

namespace HospitalPlatformMVC.Service.IService
{
    public interface IAppointmentService
    {
        Task<List<AppointmentDto>?> GetAllAppointmentsAsync();
        Task<AppointmentDto?> GetAppointmentByIdAsync(int id);
        Task<ResponseDto?> CreateAppointmentsAsync(AppointmentDto appointmentDto);
        Task<ResponseDto?> UpdateAppointmentsAsync(AppointmentDto appointmentDto);
        Task<ResponseDto?> DeleteAppointmentsAsync(int id);
    }
}
