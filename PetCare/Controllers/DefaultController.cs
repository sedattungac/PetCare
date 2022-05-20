using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace PetCare.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            AboutManager aboutManager = new AboutManager(new EfAboutDal());
            var values = aboutManager.TGetList();
            return View(values);
        }
        public IActionResult Service()
        {
            ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
            var values = serviceManager.TGetList();
            return View(values);
        }
        public IActionResult ServiceDetail(int id)
        {
            ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
            Context c = new Context();
            var header = c.Services.Where(x => x.ServiceId == id).Select(x => x.Title).FirstOrDefault();
            ViewBag.header = header;
            var values = serviceManager.GetTableById(id);
            return View(values);
        }
        public PartialViewResult ServiceList()
        {
            ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
            var values = serviceManager.TGetList();
            return PartialView(values);
        }
        public IActionResult Faq()
        {
            FaqManager faqManager = new FaqManager(new EfFaqDal());
            var values = faqManager.TGetList();
            return View(values);
        }
        public IActionResult Blog(int page = 1)
        {
            BlogManager blogManager = new BlogManager(new EfBlogDal());
            var values = blogManager.GetBlogWithAdminandCategory().ToPagedList(page, 9);
            return View(values);
        }
        public IActionResult BlogDetail(int id)
        {
            BlogManager blogManager = new BlogManager(new EfBlogDal());
            Context c = new Context();
            var header = c.Blogs.Where(x => x.BlogId == id).Select(x => x.Title).FirstOrDefault();
            ViewBag.header = header;
            var category = c.Blogs.Where(x => x.BlogId == id).Include(x => x.BlogCategory).Select(x => x.BlogCategory.Title).FirstOrDefault();
            ViewBag.category = category;
            var writer = c.Blogs.Where(x => x.BlogId == id).Include(x => x.Admin).Select(x => x.Admin.FullName).FirstOrDefault();
            ViewBag.writer = writer;
            var email = c.Blogs.Where(x => x.BlogId == id).Include(x => x.Admin).Select(x => x.Admin.Email).FirstOrDefault();
            ViewBag.email = email;
            var image = c.Blogs.Where(x => x.BlogId == id).Include(x => x.Admin).Select(x => x.Admin.ImageUrl).FirstOrDefault();
            ViewBag.image = image;
            var facebook = c.Blogs.Where(x => x.BlogId == id).Include(x => x.Admin).Select(x => x.Admin.FacebookUrl).FirstOrDefault();
            ViewBag.facebook = facebook;
            var instagram = c.Blogs.Where(x => x.BlogId == id).Include(x => x.Admin).Select(x => x.Admin.InstagramUrl).FirstOrDefault();
            ViewBag.instagram = instagram;
            var linkedin = c.Blogs.Where(x => x.BlogId == id).Include(x => x.Admin).Select(x => x.Admin.LinkedInUrl).FirstOrDefault();
            ViewBag.linkedin = linkedin;
            var twitter = c.Blogs.Where(x => x.BlogId == id).Include(x => x.Admin).Select(x => x.Admin.TwitterUrl).FirstOrDefault();
            ViewBag.twitter = twitter;
            var values = blogManager.GetTableById(id);
            return View(values);
        }
        public IActionResult Contact()
        {
            ContactManager contactManager = new ContactManager(new EfContactDal());
            var values = contactManager.TGetList();
            return View(values);
        }
    }
}
