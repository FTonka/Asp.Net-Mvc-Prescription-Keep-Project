using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCProject.Models;
using Newtonsoft.Json;

namespace MVCProject.Controllers
{
    
    public class NoteController : Controller
    {
        NoteManager nmc = new NoteManager(new EfNoteRepository());
        Context c = new Context();
        public IActionResult Index()
        {
            var values=nmc.GetDoctorInfo();
            return View(values);

        }

        public IActionResult ShowNotesByEId()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            var employeeID = c.Set<Employee>().Where(e => e.EmployeeMail == usermail)
                .Select(y => y.EmployeeID).FirstOrDefault();
            var values = nmc.GetNotesByEId(employeeID);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddNote()
        {
            DoctorManager cm = new DoctorManager(new EfDoctorRepository());
            List<SelectListItem> doctorValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.DoctorName,
                                                       Value = x.DoctorID.ToString()

                                                   }).ToList();
            ViewBag.cv = doctorValues;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddNote(Note note)

        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            var employeeID = c.Set<Employee>().Where(e => e.EmployeeMail == usermail)
                .Select(y => y.EmployeeID).FirstOrDefault();

            JSONToViewModel model = new JSONToViewModel();
            GeoHelper gh = new GeoHelper();
            var resultGeo = await gh.GetGeoInfo();
            model = JsonConvert.DeserializeObject<JSONToViewModel>(resultGeo);


            DoctorManager cm = new DoctorManager(new EfDoctorRepository());
            List<SelectListItem> doctorValues = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DoctorName,
                                                     Value = x.DoctorID.ToString()

                                                 }).ToList();
            ViewBag.cv = doctorValues;

            NoteValidator nvd = new NoteValidator();
            ValidationResult result = nvd.Validate(note);
            if (result.IsValid)
            {
                var LocationModel = (model.CountryName + "/" + model.City + " LA: " + model.Latitude + ", L0: " + model.Longitude);
                note.NoteGeoLocation = LocationModel;
                note.NoteCreateDate = DateTime.Now.ToString();
                note.EmployeeID = employeeID;
                nmc.AddNote(note);

                return RedirectToAction("ShowNotesByEId", "Note");

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


        public IActionResult DeleteNote(int id)
        {
            var value=nmc.GetById(id);
            nmc.DeleteNote(value);
            return RedirectToAction("ShowNotesByEId","Note");
        }


        [HttpGet]
        public IActionResult EditNote(int id)
        {
            var dataValue=nmc.GetById(id);
            DoctorManager cm = new DoctorManager(new EfDoctorRepository());
            List<SelectListItem> doctorValues = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DoctorName,
                                                     Value = x.DoctorID.ToString()

                                                 }).ToList();
            ViewBag.cv = doctorValues;
            return View(dataValue);

        }
        [HttpPost]
        public async Task<IActionResult> EditNoteAsync(Note note)
        {
            JSONToViewModel model = new JSONToViewModel();
            GeoHelper gh = new GeoHelper();
            var resultGeo = await gh.GetGeoInfo();
            model = JsonConvert.DeserializeObject<JSONToViewModel>(resultGeo);

            DoctorManager cm = new DoctorManager(new EfDoctorRepository());
            List<SelectListItem> doctorValues = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DoctorName,
                                                     Value = x.DoctorID.ToString()

                                                 }).ToList();
            ViewBag.cv = doctorValues;

            NoteValidator nvd = new NoteValidator();
            ValidationResult result = nvd.Validate(note);
            if (result.IsValid)
            {
                var LocationModel = (model.CountryName + "/" + model.City + " LA: " + model.Latitude + ", L0: " + model.Longitude);
                note.NoteGeoLocation = LocationModel;
                note.NoteCreateDate = DateTime.Now.ToString();
                note.EmployeeID = 1;
                nmc.UpdateNote(note);
                return RedirectToAction("ShowNotesByEId", "Note");

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

        public IActionResult ShowNotesByNoteId(int id)
        {
            var values=nmc.GetNoteDetails(id);
            return View(values);
        }


    }
}
