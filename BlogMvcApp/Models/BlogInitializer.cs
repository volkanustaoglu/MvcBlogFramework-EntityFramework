using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    public class BlogInitializer:DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            List<Category> kategoriler = new List<Category>()
            {
                new Category() {KategoriAdi="Bilişsel psikoloji2"},
                new Category() {KategoriAdi="Çalışma psikolojisi"},
                new Category() {KategoriAdi="Kültürel psikoloji"}
            };

            foreach (var item in kategoriler)
            {
                context.Kategoriler.Add(item);
            }
            context.SaveChanges();



            List<Blog> bloglar = new List<Blog>()
            {
                new Blog() {Baslik="Kendin ve İlişkin", Aciklama="“İnsan kendisiyle nasıl bir ilişki kuruyorsa bir başkasıyla da ilişkisini öyle kurar.” Her şey burada başlıyor aslında. Hatalar…", Resim="1.jpg", EklenmeTarihi="10.11.11", Anasayfa=true, Onay=true, CategoryId=1, Icerik="“İnsan kendisiyle nasıl bir ilişki kuruyorsa bir başkasıyla da ilişkisini öyle kurar.” Her şey burada başlıyor aslında. Hatalarımız, yanlışlarımız, bizi boğan düşüncelerimiz, tahammül sınırlarımız… hep bu ilişkinin altında yatar. Kendimizle olan ilişkimiz.“İnsan kendisiyle nasıl bir ilişki kuruyorsa bir başkasıyla da ilişkisini öyle kurar.” Her şey burada başlıyor aslında. Hatalarımız, yanlışlarımız, bizi boğan düşüncelerimiz, tahammül sınırlarımız… hep bu ilişkinin altında yatar. Kendimizle olan ilişkimiz.“İnsan kendisiyle nasıl bir ilişki kuruyorsa bir başkasıyla da ilişkisini öyle kurar.” Her şey burada başlıyor aslında. Hatalarımız, yanlışlarımız, bizi boğan düşüncelerimiz, tahammül sınırlarımız… hep bu ilişkinin altında yatar. Kendimizle olan ilişkimiz." },
                new Blog() {Baslik="Kendin ve İlişkin", Aciklama="“İnsan kendisiyle nasıl bir ilişki kuruyorsa bir başkasıyla da ilişkisini öyle kurar.” Her şey burada başlıyor aslında. Hatalar…", Resim="2.jpg", EklenmeTarihi="10.11.11", Anasayfa=true, Onay=true, CategoryId=2, Icerik="“İnsan kendisiyle nasıl bir ilişki kuruyorsa bir başkasıyla da ilişkisini öyle kurar.” Her şey burada başlıyor aslında. Hatalarımız, yanlışlarımız, bizi boğan düşüncelerimiz, tahammül sınırlarımız… hep bu ilişkinin altında yatar. Kendimizle olan ilişkimiz.“İnsan kendisiyle nasıl bir ilişki kuruyorsa bir başkasıyla da ilişkisini öyle kurar.” Her şey burada başlıyor aslında. Hatalarımız, yanlışlarımız, bizi boğan düşüncelerimiz, tahammül sınırlarımız… hep bu ilişkinin altında yatar. Kendimizle olan ilişkimiz.“İnsan kendisiyle nasıl bir ilişki kuruyorsa bir başkasıyla da ilişkisini öyle kurar.” Her şey burada başlıyor aslında. Hatalarımız, yanlışlarımız, bizi boğan düşüncelerimiz, tahammül sınırlarımız… hep bu ilişkinin altında yatar. Kendimizle olan ilişkimiz."},
                new Blog() {Baslik="Kendin ve İlişkin", Aciklama="“İnsan kendisiyle nasıl bir ilişki kuruyorsa bir başkasıyla da ilişkisini öyle kurar.” Her şey burada başlıyor aslında. Hatalar…", Resim="3.jpg", EklenmeTarihi="10.11.11", Anasayfa=true, Onay=true, CategoryId=3, Icerik="“İnsan kendisiyle nasıl bir ilişki kuruyorsa bir başkasıyla da ilişkisini öyle kurar.” Her şey burada başlıyor aslında. Hatalarımız, yanlışlarımız, bizi boğan düşüncelerimiz, tahammül sınırlarımız… hep bu ilişkinin altında yatar. Kendimizle olan ilişkimiz.“İnsan kendisiyle nasıl bir ilişki kuruyorsa bir başkasıyla da ilişkisini öyle kurar.” Her şey burada başlıyor aslında. Hatalarımız, yanlışlarımız, bizi boğan düşüncelerimiz, tahammül sınırlarımız… hep bu ilişkinin altında yatar. Kendimizle olan ilişkimiz.“İnsan kendisiyle nasıl bir ilişki kuruyorsa bir başkasıyla da ilişkisini öyle kurar.” Her şey burada başlıyor aslında. Hatalarımız, yanlışlarımız, bizi boğan düşüncelerimiz, tahammül sınırlarımız… hep bu ilişkinin altında yatar. Kendimizle olan ilişkimiz." },
                new Blog() {Baslik="Kendin ve İlişkin", Aciklama="“İnsan kendisiyle nasıl bir ilişki kuruyorsa bir başkasıyla da ilişkisini öyle kurar.” Her şey burada başlıyor aslında. Hatalar…", Resim="1.jpg", EklenmeTarihi="10.11.11", Anasayfa=false, Onay=true, CategoryId=1, Icerik="“İnsan kendisiyle nasıl bir ilişki kuruyorsa bir başkasıyla da ilişkisini öyle kurar.” Her şey burada başlıyor aslında. Hatalarımız, yanlışlarımız, bizi boğan düşüncelerimiz, tahammül sınırlarımız… hep bu ilişkinin altında yatar. Kendimizle olan ilişkimiz.“İnsan kendisiyle nasıl bir ilişki kuruyorsa bir başkasıyla da ilişkisini öyle kurar.” Her şey burada başlıyor aslında. Hatalarımız, yanlışlarımız, bizi boğan düşüncelerimiz, tahammül sınırlarımız… hep bu ilişkinin altında yatar. Kendimizle olan ilişkimiz.“İnsan kendisiyle nasıl bir ilişki kuruyorsa bir başkasıyla da ilişkisini öyle kurar.” Her şey burada başlıyor aslında. Hatalarımız, yanlışlarımız, bizi boğan düşüncelerimiz, tahammül sınırlarımız… hep bu ilişkinin altında yatar. Kendimizle olan ilişkimiz." }
            };

            foreach (var item in bloglar)
            {
                context.Bloglar.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}