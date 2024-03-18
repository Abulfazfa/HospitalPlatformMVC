using HospitalPlatformMVC.Models;

namespace HospitalPlatformMVC.Service.IService
{
    public interface IAppointmentService
    {
        Task<List<Appointment>?> GetAllAppointmentsAsync();
        Task<Appointment?> GetAppointmentByIdAsync(int id);
        Task<ResponseDto?> CreateAppointmentsAsync(Appointment appointmentDto);
        Task<ResponseDto?> UpdateAppointmentsAsync(Appointment appointmentDto);
        Task<ResponseDto?> DeleteAppointmentsAsync(int id);
    }
}
