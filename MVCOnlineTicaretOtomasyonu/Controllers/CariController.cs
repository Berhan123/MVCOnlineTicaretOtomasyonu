using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicaretOtomasyonu.Models.Siniflar;

namespace MVCOnlineTicaretOtomasyonu.Controllers
{
    public class CariController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            p.Durum=true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var dep = c.Carilers.Find(id);
            dep.Durum = !dep.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CariGetir(int id)
        {
            var dpt = c.Carilers.Find(id);
            return View(dpt);
        }

        public ActionResult CariGuncelle(Cariler cr)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            else
            {
                var cari = c.Carilers.Find(cr.Cariid);
                cari.CariAd = cr.CariAd;
                cari.CariMail = cr.CariMail;
                cari.CariSehir = cr.CariSehir;
                cari.CariSoyad = cr.CariSoyad;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cr = c.Carilers.Where(x => x.Cariid == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}