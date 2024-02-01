using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using HospitalPlatformMVC.Utility;

namespace HospitalPlatformMVC.Service
{
    public class AccountService : IAccountService
    {
        private readonly IBaseService _baseService;
        public AccountService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public Task<bool> AssignRole(string email, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponseDto> Login(LoginDto loginRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task<string> Register(RegisterDto registrationRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
