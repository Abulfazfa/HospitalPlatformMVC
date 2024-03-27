using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using HospitalPlatformMVC.Utility;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Service
{
    public class AccountService : IAccountService
    {
        private readonly IBaseService _baseService;
        public AccountService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> AssignRole(string email, string roleName)
        {
            var roleAssignmentDto = new RoleAssignmentDto
            {
                Email = email,
                RoleName = roleName
            };

            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = roleAssignmentDto,
                Url = SD.HospitalAPIBase + $"Account/AssignRole/"
            });
            return response;
        }

        public async Task<ResponseDto> Login(LoginDto loginRequestDto)
        {
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDto,
                Url = SD.HospitalAPIBase + $"Account/login/"
            });
            return response;
        }

        public async Task<ResponseDto> Register(RegisterDto registrationRequestDto)
        {
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequestDto,
                Url = SD.HospitalAPIBase + $"Account/register/"
            });
            return response;
        }

        public async Task<List<User>> GetAllUsers()
        {
            ResponseDto? response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.HospitalAPIBase + $"Account/get/"
            });
            return JsonConvert.DeserializeObject<List<User>>(Convert.ToString(response.Result));
        }
    }
}
