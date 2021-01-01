using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicaretOtomasyonu.Models.Siniflar;


namespace MVCOnlineTicaretOtomasyonu.Controllers
{
    public class KategoriController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var sorgu = c.Kategoris.ToList();
            return View(sorgu);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}