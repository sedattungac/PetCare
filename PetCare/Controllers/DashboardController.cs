using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PetCare.Controllers
{
    public class DashboardController : Controller
    {
        Context c = new Context();

        public IActionResult Index()
        {
            ViewBag.blogCount = c.Blogs.Count().ToString();
            ViewBag.adminCount = c.Admins.Count().ToString();
            ViewBag.serviceCount = c.Services.Count().ToString();
            ViewBag.blogCategoryCount = c.BlogCategories.Count().ToString();
            //Weather APi
            string api = "c452294241f3db3ae1c54e47167c6717";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.weather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
