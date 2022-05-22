using BlogMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class HomeController : Controller
    {

        private BlogContext context = new BlogContext();
        // GET: Home
        public ActionResult Index()
        {
            var bloglar = context.Bloglar
                .Where(i => i.Onay == true && i.Anasayfa == true)
                .Select(i => new BlogModel() { 

                    Id=i.Id,
                    Baslik=i.Baslik.Length> 42 ? i.Baslik.Substring(0,42)+"...": i.Baslik,
                    Aciklama = i.Aciklama.Length > 130 ? i.Aciklama.Substring(0, 130) + "..." : i.Aciklama,
                    EklenmeTarihi=i.EklenmeTarihi,
                    Anasayfa=i.Anasayfa,
                    Onay=i.Onay,
                    Resim=i.Resim
                
                });

           

            return View(bloglar.ToList());
        }
        public ActionResult Hakkimda()
        {
            var bloglar = context.Bloglar
               .Where(i => i.Onay == true && i.Anasayfa == true)
               .Select(i => new BlogModel()
               {

                   Id = i.Id,
                   Baslik = i.Baslik.Length > 42 ? i.Baslik.Substring(0, 42) + "..." : i.Baslik,
                   Aciklama = i.Aciklama.Length > 130 ? i.Aciklama.Substring(0, 130) + "..." : i.Aciklama,
                   EklenmeTarihi = i.EklenmeTarihi,
                   Anasayfa = i.Anasayfa,
                   Onay = i.Onay,
                   Resim = i.Resim

               });



            return View(bloglar.ToList());
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult CalismaAlanlarim()
        {
            return View();
        }
        
        public ActionResult SSS()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Iletisim(EpostaModel model)
        {
            string server = ConfigurationManager.AppSettings["server"];
            int port = int.Parse(ConfigurationManager.AppSettings["port"]);
            bool ssl = ConfigurationManager.AppSettings["ssl"].ToString() == "1" ? true : false;
            string from = ConfigurationManager.AppSettings["from"];
            string password = ConfigurationManager.AppSettings["password"];
            string fromname = ConfigurationManager.AppSettings["fromname"];
            string to = ConfigurationManager.AppSettings["to"];
            string copyto = ConfigurationManager.AppSettings["epostacopy"];

            var client = new SmtpClient();
            client.Host = server;
            client.Port = port;
            client.EnableSsl = ssl;
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential(from, password);

            var email = new MailMessage();
            email.From = new MailAddress(from, fromname);
            email.To.Add(to);

            if (string.IsNullOrEmpty(copyto)==false)
            {
                string[] mails = copyto.Split(',');
                foreach (var item in mails)
                {
                    email.Bcc.Add(item);
                }
            }

            email.Subject = model.konu;
            email.IsBodyHtml = true;
            email.Body = $"ad soyad : {model.adsoyad} \n email: {model.email} \n telefon: {model.telefon} \n konu: {model.konu}  mesaj: {model.mesaj}";

            try
            {
                client.Send(email);
                ViewData["result"] = true;
            }
            catch (Exception)
            {

                ViewData["result"] = false;
            }
            return View();
        }
    }
}