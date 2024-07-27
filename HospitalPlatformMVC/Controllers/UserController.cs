using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Controllers
{
	public class UserController : Controller
	{
		
		private readonly IAccountService _accountService;

        public UserController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(LoginDto loginDto)
		{
			if (!ModelState.IsValid)
			{
				return View(loginDto);
            }

            var result = _accountService.Login(loginDto).Result;

            if (result.IsSuccess)
			{
				return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
			}
			else
			{
				ModelState.AddModelError(string.Empty, result.Message);
				return View(loginDto);
			}

		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(RegisterDto registerDto)
		{
			if (!ModelState.IsValid)
			{
				return View(registerDto);
			}

            var result = _accountService.Register(registerDto).Result;

            if (result.IsSuccess)
			{
				return RedirectToAction(nameof(Login));
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
				return View(registerDto);
			}
		}

	}
}
