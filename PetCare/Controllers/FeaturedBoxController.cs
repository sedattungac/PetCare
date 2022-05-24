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
    public class FeaturedBoxController : Controller
    {
        FeaturedBoxManager featuredBoxManager = new FeaturedBoxManager(new EfFeaturedBoxDal());

        public IActionResult Index()
        {
            var values = featuredBoxManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = featuredBoxManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Edit(FeaturedBox featuredBox)
        {
            featuredBoxManager.TUpdate(featuredBox);
            return View("Index");
        }
    }
}
