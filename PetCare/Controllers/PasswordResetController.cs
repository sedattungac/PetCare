﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelTakipOtomasyonu.Controllers
{
    public class PasswordResetController : Controller
    {
        private readonly Context _context;
        public PasswordResetController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reset(string email)
        {
            var mail = _context.Admins.Where(x => x.Email == email).SingleOrDefault();
            var username = _context.Admins.Where(x => x.Email == email).Select(y => y.FullName).FirstOrDefault();
            if (mail != null)
            {
                Random rnd = new Random();
                int newpassword = rnd.Next();
                Admin password = new Admin();
                mail.Password = Convert.ToString(newpassword);
                _context.SaveChanges();

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Gündoğan Veterinerlik", "gundoganveterinerlikdestek@gmail.com"));
                message.To.Add(new MailboxAddress(username, email.ToString()));
                message.Subject = "Şifre Sıfırlama";
                message.Body = new TextPart("plain")
                {
                    Text = "Yeni Şifreniz: " + newpassword.ToString() + " " + "sisteme giriş yapmak için tıklayınız => https://gundoganveterinerlik.com/Login"
                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("gundoganveterinerlikdestek@gmail.com", "A.sd1234567");
                    client.Send(message);
                    client.Disconnect(true);
                }
                ViewBag.alert = "Yeni Şifreniz Başarıyla Gönderilmiştir";
            }
            else
            {
                ViewBag.alert = "Hata Oluştu!";
                ViewBag.message = "Girmiş olduğunuz mail sisteme kayıtlı değil lütfen tekrar deneyiniz";
            }
            return View("Index");
        }
    }
}
