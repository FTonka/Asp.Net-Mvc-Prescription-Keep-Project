using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeManager emc = new EmployeeManager(new EfEmployeeRepository());

        Context c = new Context();
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v=usermail;
            var Name = c.Set<Employee>().Where(x => x.EmployeeMail == usermail).Select(y => y.EmployeeName).FirstOrDefault();
            ViewBag.v1 = Name;
            var Surname = c.Set<Employee>().Where(x => x.EmployeeMail == usermail).Select(y => y.EmployeeSurname).FirstOrDefault();
            ViewBag.v2 = Surname;
            var Job = c.Set<Employee>().Where(x => x.EmployeeMail == usermail).Select(y => y.EmployeesDepartment).FirstOrDefault();
            ViewBag.v3 = Job;
            return View();
        }

        public PartialViewResult EmployeeNavbarPartial()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;



            return PartialView();
        }
        public PartialViewResult EmployeeFooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult LastMessages()
        {
            return PartialView();
        }
        public PartialViewResult LastNotifications()
        {
            return PartialView(); 
        }
        [HttpGet]
        public IActionResult EditProfile()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            var employeeID = c.Set<Employee>().Where(e => e.EmployeeMail == usermail)
                .Select(y => y.EmployeeID).FirstOrDefault();
            ViewBag.n = employeeID;
            var EmployeeValues = emc.GetById(employeeID);
            return View(EmployeeValues);
        }
        [HttpPost]
        public IActionResult EditProfile(Employee e)
        {
            EmployeeValidator ev = new EmployeeValidator();
            ValidationResult result = ev.Validate(e);
            if (result.IsValid)
            {
                if(e.EmployeeImg != null)
                {
                    var extension=Path.GetExtension(e.EmployeeImg);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/writer/EmployeeImageFile/", newImageName);
                    var stream=new FileStream(location,FileMode.Create);
                    e.EmployeeImg = newImageName;

                }
                emc.UpdateEmployee(e);
                return RedirectToAction("Index", "Employee");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
        }


    }
}
