using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp9RoleBasedApp.Controllers
{
    [Authorize]  // for alle loggede brugere
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Developer,Admin")]
        public IActionResult DevExclusive()
        {
            return View();
        }
    }
}
