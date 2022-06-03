using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerBI.Api.Models;
using System.Security.Claims;

namespace MVCProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<Employee> _signInManager;
        public LoginController(SignInManager<Employee> signInManager) 
        {
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Employee e)
        {
            Context c = new Context();
            var datavalue = c.Set<Employee>().FirstOrDefault(x => x.EmployeeMail == e.EmployeeMail && x.EmployeePassword == e.EmployeePassword);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,e.EmployeeMail),
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal=new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
              
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View();
            }
            
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
