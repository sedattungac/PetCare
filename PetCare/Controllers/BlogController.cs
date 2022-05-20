using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        BlogCategoryManager blogCategoryManager = new BlogCategoryManager(new EfBlogCategoryDal());
        public IActionResult Index()
        {
            var values = blogManager.GetBlogWithAdminandCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> dropdownlist1 = (from x in c.BlogCategories.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Title,
                                                      Value = x.BlogCategoryId.ToString()
                                                  }).ToList();
            ViewBag.list1 = dropdownlist1;
            List<SelectListItem> dropdownlist2 = (from x in c.Admins.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.FullName,
                                                      Value = x.AdminId.ToString()
                                                  }).ToList();
            ViewBag.list2 = dropdownlist2;
            return View();
        }
        [HttpPost]
        public IActionResult Add(Blog blog)
        {
            blog.Date = DateTime.Now;
            blogManager.TAdd(blog);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<SelectListItem> dropdownlist1 = (from x in c.BlogCategories.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Title,
                                                      Value = x.BlogCategoryId.ToString()
                                                  }).ToList();
            ViewBag.list1 = dropdownlist1;
            List<SelectListItem> dropdownlist2 = (from x in c.Admins.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.FullName,
                                                      Value = x.AdminId.ToString()
                                                  }).ToList();
            ViewBag.list2 = dropdownlist2;
            var values = blogManager.TGetById(id);
            return View(values);

        }
        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            blogManager.TUpdate(blog);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var values = blogManager.TGetById(id);
            blogManager.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
