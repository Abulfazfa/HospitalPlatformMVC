using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Controllers
{
	public class DoctorController : Controller
	{
        private readonly IUnitOfWork _unitOfWork;

        public DoctorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
		{
            List<Doctor>? list = _unitOfWork.DoctorService.GetAllAsync().Result;

            ViewBag.Categories = _unitOfWork.GroupService.GetAllAsync().Result;
            return View(list);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Doctor? doctor = GetDoctor(id);
            return View(doctor);
        }


        private Doctor? GetDoctor(int id)
        {
            return _unitOfWork.DoctorService.GetByIdAsync(id).Result;
        }


        [HttpGet]
        public IActionResult GetDoctorsByDepartment(string depName)
        {
            List<Doctor> allDoctors = _unitOfWork.DoctorService.GetAllAsync().Result;

            // Filter doctors based on department name
            List<Doctor> doctorsInDepartment = allDoctors.Where(d => d.Branch == depName).ToList();
            return Json(doctorsInDepartment);
        }

        [HttpGet]
        public IActionResult GetAvailableTimes(int doctorId, DateTime? date)
        {
            try
            {
                // Call a service method to get available times based on department, doctor, and date
                Doctor doctor = GetDoctor(doctorId);
                string[] times = { "8:00 - 9:00", "9:00 - 10:00", "10:00 - 11:00", "11:00 - 12:00", "12:00 - 13:00" };
                List<string> updatesTimes = new List<string>();
                updatesTimes = times.ToList();
                if (doctor.Appointments.Count > 0)
                {
                    foreach (var item in doctor.Appointments.Where(a => a.ConsultingDate == date.Value.ToString("yyyy-MM-dd")))
                    {
                        if (times.Contains(item.Time))
                        {
                            updatesTimes.Remove(item.Time);
                        }
                    }
                }
                return Json(updatesTimes);
            } 
            catch (Exception ex)
            {
                return BadRequest("An error occurred while retrieving available times.");
            }
        }


    }
}

