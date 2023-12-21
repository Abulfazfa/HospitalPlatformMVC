using HospitalPlatformMVC.Models;

namespace HospitalPlatformMVC.Service.IService
{
    public interface IDoctorService
    {
        Task<ResponseDto?> GetAllDoctorsAsync();
        Task<ResponseDto?> GetDoctorByIdAsync(int id);
        Task<ResponseDto?> CreateDoctorsAsync(DoctorDto doctorDto);
        Task<ResponseDto?> UpdateDoctorsAsync(DoctorDto doctorDto);
        Task<ResponseDto?> DeleteDoctorsAsync(int id);
    }
}
