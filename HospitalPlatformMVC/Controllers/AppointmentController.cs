using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;        
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService, IUnitOfWork unitOfWork)
        {
            _appointmentService = appointmentService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(int doctorId)
        {
			if (doctorId == 0)
            {
				
				ViewBag.Doctors = _unitOfWork.DoctorService.GetAllAsync().Result;
				ViewBag.Categories = _unitOfWork.GroupService.GetAllAsync().Result;
			}
            else
            {
                var doctorDto = _unitOfWork.DoctorService.GetByIdAsync(doctorId).Result;
				ViewBag.Doctors = doctorDto;
				ViewBag.Categories = doctorDto.Branch;
			}
            return View();
        }

        public async Task<IActionResult> MyAppointments()
        {
            // After user registration she/he can open
            return View();
        }
        public async Task<IActionResult> AddAppointment(Appointment appointment)
        {
            try
            {
                Doctor doctorDto = GetDoctor(appointment.DoctorId);
                List<Appointment> appointments = new List<Appointment>();
                _appointmentService.CreateAppointmentsAsync(appointment);
                return NoContent();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private Doctor? GetDoctor(int id)
        {
            return _unitOfWork.DoctorService.GetByIdAsync(id).Result;
        }

    }
}
