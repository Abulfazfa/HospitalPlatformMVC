using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IGroupService _groupService;

        public DoctorController(IDoctorService doctorService, IGroupService groupService)
        {
            _doctorService = doctorService;
            _groupService = groupService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            var product = _doctorService.GetDoctorByIdAsync(id).Result;
            return View(product);
        }
        public async Task<IActionResult> DoctorCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DoctorCreate(DoctorDto doctorDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto response = await _doctorService.CreateDoctorsAsync(doctorDto);

                if (response != null && !response.IsSuccess)
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
        public IActionResult Delete(int id)
        {
            if (!_doctorService.DeleteDoctorsAsync(id).Result.IsSuccess)
                return RedirectToAction(nameof(Index));
            return BadRequest();
        }
        public IActionResult Update(int id)
        {
            ViewBag.Id = id;
            var doctor = _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
                return NotFound();

            ViewBag.Categories = _groupService.GetAllDepartmentsAsync().Result;
            return View(doctor);
        }
        [HttpPost]
        public IActionResult Update(int id, DoctorDto doctor)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Update), doctor);

            if (!_doctorService.UpdateDoctorsAsync(doctor).Result.IsSuccess)
                return RedirectToAction(nameof(Index));
            else
                return NotFound();
        }
    }
}
