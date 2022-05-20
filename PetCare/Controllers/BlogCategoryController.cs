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
    public class BlogCategoryController : Controller
    {
        BlogCategoryManager blogCategoryManager = new BlogCategoryManager(new EfBlogCategoryDal());
        public IActionResult Index()
        {
            var values = blogCategoryManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(BlogCategory blogCategory)
        {
            blogCategoryManager.TAdd(blogCategory);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = blogCategoryManager.TGetById(id);
            return View(values);

        }
        [HttpPost]
        public IActionResult Edit(BlogCategory blogCategory)
        {
            blogCategoryManager.TUpdate(blogCategory);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var values = blogCategoryManager.TGetById(id);
            blogCategoryManager.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
