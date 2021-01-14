using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicaretOtomasyonu.Models.Siniflar;

namespace MVCOnlineTicaretOtomasyonu.Controllers
{
    public class SatisController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var satis = c.SatisHarekets.ToList();
            return View(satis);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> urun = (from x in c.Uruns.ToList()
                                         where x.Durum == true
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.Urunid.ToString()
                                         }).ToList();
            List<SelectListItem> cariler = (from x in c.Carilers.ToList()
                                            where x.Durum == true
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.Cariid.ToString()
                                            }).ToList();
            List<SelectListItem> personel = (from x in c.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.Personelid.ToString()
                                             }).ToList();
            ViewBag.personel = personel;
            ViewBag.urun = urun;
            ViewBag.cariler = cariler;

            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            var deger = c.SatisHarekets.Find(id);
            List<SelectListItem> urun = (from x in c.Uruns
                                         where x.Durum == true
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.Urunid.ToString()
                                         }).ToList();
            List<SelectListItem> cariler = (from x in c.Carilers
                                            where x.Durum == true
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.Cariid.ToString()
                                            }).ToList();
            List<SelectListItem> personel = (from x in c.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.Personelid.ToString()
                                             }).ToList();
            ViewBag.personel = personel;
            ViewBag.urun = urun;
            ViewBag.cariler = cariler;
            return View("SatisGetir", deger);
        }

        public ActionResult SatisGüncelle(SatisHareket p)
        {
            var deger = c.SatisHarekets.Find(p.Satisid);
            deger.Cariid = p.Cariid;
            deger.Adet = p.Adet;
            deger.Fiyat = p.Fiyat;
            deger.Personelid = p.Personelid;
            deger.Tarih = p.Tarih;
            deger.Urunid = p.Urunid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Satisid == id).ToList();
            return View(degerler);
        }
    }
}