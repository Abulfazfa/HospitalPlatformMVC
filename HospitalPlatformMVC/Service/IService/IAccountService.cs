using HospitalPlatformMVC.Models;

namespace HospitalPlatformMVC.Service.IService
{
    public interface IAccountService
    {
        Task<string> Register(RegisterDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
