﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            // var bloglar = c.Blogs.ToList();
            by.Deger1 = c.Blogs.ToList(); //yorum ismindeki sınıf üzerinden blogları listeleme
            by.Deger3 = c.Blogs.Take(3).ToList(); //bloğu al anlamında
            return View(by);
        }

        public ActionResult BlogDetay(int id)
        {
            //var blogbul= c.Blogs.Where(x=>x.ID == id).ToList();
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id) //sayfaya taşınan id değerini alacak
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y) //yorumlardan y parametresi türetme
        {
            c.Yorumlars.Add(y); // bden gelen değeri context blogsa ekle
            c.SaveChanges();
            return PartialView();
        }
    }
}