using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCOnlineTicaretOtomasyonu.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        public string KategoriAd { get; set; }

    }
}