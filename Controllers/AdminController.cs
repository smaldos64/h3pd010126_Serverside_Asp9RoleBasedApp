using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp9RoleBasedApp.Controllers
{
    [Authorize(Policy = "RequireDeveloperOrAdmin")]
    public class AdminController : Controller
    {
        [Authorize(Policy = "RequireAdmin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DevAndAdminFeature()
        {
            return View();
        }
    }
}

