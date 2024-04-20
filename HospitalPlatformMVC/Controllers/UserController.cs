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

			var loginResult = _accountService.Login(loginDto).Result;

			if (loginResult.IsSuccess)
			{
				return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Invalid username or password.");
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

			var registrationResult = _accountService.Register(registerDto).Result;

			if (registrationResult.IsSuccess)
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
