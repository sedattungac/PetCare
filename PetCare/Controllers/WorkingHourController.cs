using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Controllers
{
    public class WorkingHourController : Controller
    {
        WorkingHourManager workingHourManager = new WorkingHourManager(new EfWorkingHourDal());
        public IActionResult Index()
        {
            var values = workingHourManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = workingHourManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Edit(WorkingHour workingHour)
        {
            workingHourManager.TUpdate(workingHour);
            return RedirectToAction("Index");
        }
    }
}
