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
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        FeaturedBoxManager featuredBoxManager = new FeaturedBoxManager(new EfFeaturedBoxDal());

        [HttpGet]
        public IActionResult Index(int id=1)
        {
            var values = featureManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            featureManager.TUpdate(feature);
            return View("Index");
        }
    }
}
