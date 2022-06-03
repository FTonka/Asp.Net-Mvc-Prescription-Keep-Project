using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        EmployeeManager emng = new EmployeeManager(new EfEmployeeRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(Employee p)
        {
            EmployeeValidator evr = new EmployeeValidator();
            ValidationResult result =evr.Validate(p);
            if (result.IsValid)
            {
                p.CreateDate = DateTime.Now.ToString();
                emng.AddEmployee(p);
                return RedirectToAction("Index", "Hospital");
                
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }



        }
    }
}
