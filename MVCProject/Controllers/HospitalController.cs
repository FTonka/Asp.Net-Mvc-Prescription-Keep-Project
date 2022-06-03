using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    [AllowAnonymous]
    public class HospitalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
