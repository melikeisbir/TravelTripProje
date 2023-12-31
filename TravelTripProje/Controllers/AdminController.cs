﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View(); //burada sadece sayfanın boş halini döndürecek
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p) 
        {
            c.Blogs.Add(p); //contexten türettiğim c nesnesine bağlı olarak blog nesnesine ekle. textboxforlardaki parametreden gelen değerleri
            c.SaveChanges();
            return RedirectToAction("Index"); //post işlemi yapıldıgı zaman yani bir şey gönderildiği zaman burdaki döndürülecek.
                                             //Index aksiyonuna yönlendir

        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);  //context.bloglar. id'den gelen blogları bul
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var bl=c.Blogs.Find(id);
            return View("BlogGetir",bl); // bloggetir sayfası olacak ve bu sayfayı döndürürken bl'den gelen değerleride getir
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg=c.Blogs.Find(b.ID);
            blg.Aciklama=b.Aciklama;
            blg.Baslik=b.Baslik;
            blg.BlogImage=b.BlogImage;
            blg.Tarih=b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id); 
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}