using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalPlatformMVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            var product = _unitOfWork.DoctorService.GetByIdAsync(id).Result;
            return View(product);
        }
        public async Task<IActionResult> DoctorCreate()
        {
            var groups = await _unitOfWork.GroupService.GetAllAsync();
            ViewBag.Categories = groups.Select(g => new SelectListItem
            {
                Text = g.Name, 
                Value = g.Name.ToString() 
            }).ToList();

            var offices = await _unitOfWork.OfficeService.GetAllAsync();
            ViewBag.Offices = offices.Select(g => new SelectListItem
            {
                Text = g.Name,
                Value = g.Name.ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DoctorCreate(Doctor doctorDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto response = _unitOfWork.DoctorService.CreateAsync(doctorDto).Result;

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
            if (!_unitOfWork.DoctorService.DeleteAsync(id).Result.IsSuccess)
                return RedirectToAction(nameof(Index));
            return BadRequest();
        }
        public IActionResult Update(int id)
        {
            ViewBag.Id = id;
            var doctor = _unitOfWork.DoctorService.GetByIdAsync(id);
            if (doctor == null)
                return NotFound();

            ViewBag.Categories = _unitOfWork.GroupService.GetAllAsync().Result;
            return View(doctor);
        }

        [HttpPost]
        public IActionResult Update(int id, Doctor doctor)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Update), doctor);

            if (!_unitOfWork.DoctorService.UpdateAsync(doctor).Result.IsSuccess)
                return RedirectToAction(nameof(Index));
            else
                return NotFound();
        }
    }
}
