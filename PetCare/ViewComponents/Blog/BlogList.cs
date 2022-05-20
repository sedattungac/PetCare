using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.ViewComponents.Blog
{
    public class BlogList : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var value = c.Blogs.Include(x => x.BlogCategory).Include(x => x.Admin).Take(3).ToList();
            return View(value);
        }
    }
}
