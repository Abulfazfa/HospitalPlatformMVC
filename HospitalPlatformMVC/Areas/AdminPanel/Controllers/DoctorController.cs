using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Areas.AdminPanel.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
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
        public IActionResult Delete(int id)
        {
            if (_doctorService.DeleteProduct(id).Result)
                return RedirectToAction(nameof(Index));
            return BadRequest();
        }
        public IActionResult Update(int id)
        {
            ViewBag.Id = id;
            var product = _doctorService.GetProductDetail(id);
            if (product == null)
                return NotFound();

            var productVM = _doctorService.MapProductVMAndProduct(id);

            ViewBag.Categories = _doctorService.GetCategorySelectList();
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Update(int id, ProductVM productVM)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Update), productVM);

            if (_doctorService.UpdateProduct(id, productVM))
                return RedirectToAction(nameof(Index));
            else
                return NotFound();
        }
    }
}
