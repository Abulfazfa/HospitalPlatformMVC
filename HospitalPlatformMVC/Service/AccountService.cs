using AutoMapper;
using HospitalPlatformMVC.Helper;
using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using HospitalPlatformMVC.Utility;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Service
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IBaseService _baseService;
        private readonly IMapper _mapper;
        public AccountService(IBaseService baseService, IMapper mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
        }

        public async Task AssignRole(User appUser)
        {
            await _userManager.AddToRoleAsync(appUser, RoleEnum.User.ToString());
        }

        public async Task<ResponseDto> Login(LoginDto loginRequestDto)
        {
            User? user = _userManager.FindByNameAsync(loginRequestDto.UsernameOrEmail).Result;
            var result = _signInManager.PasswordSignInAsync(user, loginRequestDto.Password, true, true);

            if (result.IsCompleted)
            {
                return new ResponseDto
                {
                    IsSuccess = true,
                };
            }
            else 
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = result.Exception.Message
                };
            }
        }

        public async Task<ResponseDto> Register(RegisterDto registrationRequestDto)
        {
            User appUser = CreateUserFromRegisterDto(registrationRequestDto);
            var result = await _userManager.CreateAsync(appUser, registrationRequestDto.Password);

            if (!result.Succeeded)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = result.Errors.ToString()
                };
            }

            await AssignRole(appUser);

            return new ResponseDto
            {
                IsSuccess = true
            };
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

        public User CreateUserFromRegisterDto(RegisterDto registerDto)
        {
            return _mapper.Map<User>(registerDto);
        }
    }
}
