using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service;
using HospitalPlatformMVC.Service.IService;
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
			ResponseDto responseDto = _appointmentService.GetAllAppointmentsAsync().Result;
			var appointmentList = JsonConvert.DeserializeObject<List<AppointmentDto>>(Convert.ToString(responseDto.Result));
			return View(appointmentList.Where(d => d.DoctorId == docId));
		}
	}
}
