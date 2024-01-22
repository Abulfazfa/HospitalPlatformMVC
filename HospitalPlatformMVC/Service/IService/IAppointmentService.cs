using HospitalPlatformMVC.Models;

namespace HospitalPlatformMVC.Service.IService
{
    public interface IAppointmentService
    {
        Task<ResponseDto?> GetAllAppointmentsAsync();
        Task<ResponseDto?> GetAppointmentByIdAsync(int id);
        Task<ResponseDto?> CreateAppointmentsAsync(AppointmentDto appointmentDto);
        Task<ResponseDto?> UpdateAppointmentsAsync(AppointmentDto appointmentDto);
        Task<ResponseDto?> DeleteAppointmentsAsync(int id);
    }
}
