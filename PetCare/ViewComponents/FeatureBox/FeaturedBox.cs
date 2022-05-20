using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.ViewComponents.FeatureBox
{
    public class FeaturedBox : ViewComponent
    {
        FeaturedBoxManager featuredBoxManager = new FeaturedBoxManager(new EfFeaturedBoxDal());
        public IViewComponentResult Invoke()
        {
            var values = featuredBoxManager.TGetList();
            return View(values);
        }
    }
}
