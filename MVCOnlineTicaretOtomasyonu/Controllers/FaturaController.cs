using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicaretOtomasyonu.Models.Siniflar;

namespace MVCOnlineTicaretOtomasyonu.Controllers
{
    public class FaturaController : Controller
    {
        Context c =new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {

            var fatura = c.Faturalars.Find(id);

            return View("FaturaGetir",fatura);
        }

        public ActionResult FaturaGüncelle(Faturalar f)
        {
            var deger = c.Faturalars.Find(f.Faturaid);
            deger.Tarih = f.Tarih;
            deger.FaturaSeriNo = f.FaturaSeriNo;
            deger.FaturaSıraNo = f.FaturaSıraNo;
            deger.Saat = f.Saat;
            deger.TeslimAlan = f.TeslimAlan;
            deger.TeslimEden = f.TeslimEden;
            deger.VerigiDairesi = f.VerigiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var degerPersonel = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();

            return View(degerPersonel);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}