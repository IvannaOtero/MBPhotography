using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MBPhotography.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManageAppointments()
        {
            return View();
        }

        public IActionResult ManagePackages()
        {
            return View();
        }

        public IActionResult ManageUsers()
        {
            return View();
        }
    }
}
