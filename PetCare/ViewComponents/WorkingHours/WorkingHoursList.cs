using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.ViewComponents.WorkingHours
{
    public class WorkingHoursList : ViewComponent
    {
        WorkingHourManager workingHourManager = new WorkingHourManager(new EfWorkingHourDal());
        public IViewComponentResult Invoke()
        {
            var value = workingHourManager.TGetList();
            return View(value);
        }
    }
}
