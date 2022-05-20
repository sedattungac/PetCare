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
    public class FaqController : Controller
    {
        FaqManager faqManager = new FaqManager(new EfFaqDal());
        public IActionResult Index()
        {
            var values = faqManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Faq faq)
        {
            faqManager.TAdd(faq);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = faqManager.TGetById(id);
            return View(values);

        }
        [HttpPost]
        public IActionResult Edit(Faq faq)
        {
            faqManager.TUpdate(faq);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var values = faqManager.TGetById(id);
            faqManager.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
