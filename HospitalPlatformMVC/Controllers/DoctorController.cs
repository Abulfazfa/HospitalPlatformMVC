using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Controllers
{
	public class DoctorController : Controller
	{
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task<IActionResult> Index()
		{
            List<DoctorDto>? list = new();

            ResponseDto? response = await _doctorService.GetAllDoctorsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<DoctorDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DoctorCreate(DoctorDto doctorDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _doctorService.CreateDoctorsAsync(doctorDto);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Doctor created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(doctorDto);
        }

    }
}

