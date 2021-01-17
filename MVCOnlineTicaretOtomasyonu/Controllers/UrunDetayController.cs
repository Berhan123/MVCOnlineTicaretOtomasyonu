using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicaretOtomasyonu.Models.Siniflar;

namespace MVCOnlineTicaretOtomasyonu.Controllers
{
    public class UrunDetayController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            //var degerler = c.Uruns.Where(x => x.Urunid == 1).ToList();

            Class1 cs= new Class1();
            cs.Deger1 = c.Uruns.Where(x => x.Urunid == 1).ToList();
            cs.Deger2 = c.Detays.Where(y => y.DetayID == 1).ToList();
            return View(cs);
        }
    }
}