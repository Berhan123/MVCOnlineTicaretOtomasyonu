using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicaretOtomasyonu.Models.Siniflar;

namespace MVCOnlineTicaretOtomasyonu.Controllers
{
    public class DepartmanController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman p)
        {
            c.Departmans.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmans.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departmans.Find(id);
            return View("DepartmanGetir",dpt);
        }

        public ActionResult DepartmanGuncelle(Departman departman)
        {
            var dep = c.Departmans.Find(departman.Departmanid);
            dep.Departmanad = departman.Departmanad;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerPersonel = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.Departmans.Where(x => x.Departmanid == id).Select(y => y.Departmanad).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerPersonel);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var dpt = c.Personels.Where(x => x.Personelid == id).Select(y => y.PersonelAd+" "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }
    }
}