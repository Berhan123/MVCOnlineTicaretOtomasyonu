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
        Context c=new Context();
        public ActionResult Index()
        {
            var satis = c.SatisHarekets.ToList();
            return View(satis);
        }
    }
}