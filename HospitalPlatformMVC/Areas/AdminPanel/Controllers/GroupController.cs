using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public IActionResult Index()
        {
            var groups = _groupService.GetAllDepartmentsAsync().Result;
            return View(groups);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(object obj)
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(object obj)
        {
            return View();
        }
    }
}
