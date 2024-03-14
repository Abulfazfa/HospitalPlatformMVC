using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Areas.DoctorPanel.Controllers
{
	[Area("DoctorPanel")]
	public class PasientController : Controller
	{
		private readonly UserManager<UserDto> _userManager;

		public PasientController(/*UserManager<UserDto> userManager*/)
		{
			//_userManager = userManager;
		}

		public IActionResult Index()
		{
			var users = _userManager.Users.ToList();
			return View(users);
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(UserDto userDto)
		{
			if (userDto != null)
			{
				_userManager.CreateAsync(userDto, "12345");
			}
			return Content("User add successfully");
		}
		public IActionResult Search()
		{
			//var products = _productService.GetAll()
		 //  .Where(p => p.Name.ToLower().Contains(search.ToLower()))
		 //  .Take(3)
		 //  .OrderByDescending(p => p.Id)
		 //  .ToList();
			return PartialView("_SearchPartial"/*, products*/);
		}
	}
}
