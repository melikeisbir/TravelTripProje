using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context c=new Context(); //context sınıfıyla c nesnesi türetildi. c nesnesi yardımıylada contexte bağlı olan sınıflar içeriisnden hakkımızda olan tabloya bağlanıp listeleme
        public ActionResult Index()
        { 
            var degerler= c.Hakkimizdas.ToList();
            return View(degerler);
        }
    }
}