using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogMvcApp.Models;

namespace BlogMvcApp.Controllers
{
    
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();


        public ActionResult List (int? id)
        {
           

            var bloglar = db.Bloglar
                .Where(i => i.Onay == true)
                .Select(i => new BlogModel()
                {   

                    Id = i.Id,
                    Baslik = i.Baslik.Length > 42 ? i.Baslik.Substring(0, 42) + "..." : i.Baslik,
                    Aciklama = i.Aciklama.Length > 130 ? i.Aciklama.Substring(0, 130) + "..." : i.Aciklama,
                    EklenmeTarihi = i.EklenmeTarihi,
                    Anasayfa = i.Anasayfa,
                    Onay = i.Onay,
                    Resim = i.Resim,
                    CategoryId=i.CategoryId

                }).AsQueryable();

           

            if (id != null)
            {
                bloglar = bloglar.Where(i => i.CategoryId == id);
            }
                



            return View(bloglar.ToList());
        }

        // GET: Blog
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var bloglar = db.Bloglar.Include(b => b.Category).OrderByDescending(i=>i.EklenmeTarihi);
            return View(bloglar.ToList());
        }

       

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);


            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi");
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "Baslik,Aciklama,Resim,Icerik,CategoryId")] Blog blog,HttpPostedFileBase Resim)
        {
            if (ModelState.IsValid)
            {
                if (Resim != null)
                {
                    FileInfo dosyaBilgisi = new FileInfo(Resim.FileName);
                    string yeniIsim = Guid.NewGuid().ToString("N") + dosyaBilgisi.Extension;
                    Resim.SaveAs(Server.MapPath("~/Upload/Resim"+yeniIsim));
                    blog.Resim = yeniIsim;

                    blog.EklenmeTarihi = DateTime.Now.Date.ToString("MMMM", new System.Globalization.CultureInfo("tr-TR")) +" "+ DateTime.Now.Date.ToString("yyyy");
                db.Bloglar.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Lütfen Bir Resim Seçiniz");
                    return View(blog);
                }
               
                
            }

            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }


        // GET: Blog/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,Baslik,Aciklama,Resim,Icerik,Onay,Anasayfa,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {   

                var entity = db.Bloglar.Find(blog.Id);
                if (entity !=null)
                {
                    entity.Baslik = blog.Baslik;
                    entity.Aciklama = blog.Aciklama;
                    entity.Resim = blog.Resim;
                    entity.Icerik = blog.Icerik.Normalize();
                    entity.Onay = blog.Onay;
                    entity.Anasayfa = blog.Anasayfa;
                    entity.CategoryId = blog.CategoryId;

                    db.SaveChanges();

                    TempData["Blog"] = entity;
                    return RedirectToAction("Index");
                }
                
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }
        [Authorize(Roles = "admin")]
        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Bloglar.Find(id);
            db.Bloglar.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
