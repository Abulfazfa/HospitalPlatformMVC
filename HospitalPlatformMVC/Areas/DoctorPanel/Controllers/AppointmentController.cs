using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Areas.DoctorPanel.Controllers
{
	[Area("DoctorPanel")]
	public class AppointmentController : Controller
	{
		private readonly IAppointmentService _appointmentService;

		public AppointmentController(IAppointmentService appointmentService)
		{
			_appointmentService = appointmentService;
		}

		public IActionResult Index(int docId)
		{
			var appointmentList = _appointmentService.GetAllAppointmentsAsync().Result;
			return View(appointmentList.Where(d => d.DoctorId == docId).ToList());
		}
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appointment appointmentDto)
        {
            if (appointmentDto != null)
            {
                _appointmentService.CreateAppointmentsAsync(appointmentDto);
            }
            return Content("Appointment add successfully");
        }
    }
}
