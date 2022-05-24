using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PetCare.Controllers
{

    public class LoginController : Controller
    {
        Context _context = new Context();

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        //public IActionResult Login(string email, string password)
        public IActionResult Login(string UserName, string Password)
        {
            var user = _context.Admins.FirstOrDefault(w => w.UserName.Equals(UserName) && w.Password.Equals(Password));
            //var user = _context.Admins.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("id", user.AdminId);
                HttpContext.Session.SetString("email", user.Email);
                HttpContext.Session.SetString("fullname", user.FullName);
                HttpContext.Session.SetString("image", user.ImageUrl);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.alert = "Hatalı Giriş! Lütfen tekrar deneyiniz!";

            }
            return View("Index");
            //return RedirectToAction("Index", "Login");

        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
