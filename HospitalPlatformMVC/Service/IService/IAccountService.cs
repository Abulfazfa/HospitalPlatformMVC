using HospitalPlatformMVC.Models;

namespace HospitalPlatformMVC.Service.IService
{
    public interface IAccountService
    {
        Task<ResponseDto> Register(RegisterDto registrationRequestDto);
        Task<ResponseDto> Login(LoginDto loginRequestDto);
        Task AssignRole(User appUser);
        Task<List<User>> GetAllUsers();
    }
}
