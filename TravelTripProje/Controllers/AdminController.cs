using System;
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
    }
}