using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Areas.DoctorPanel.Controllers
{
	public class PasientController : Controller
	{
		public IActionResult Index()
		{
			return View();
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
