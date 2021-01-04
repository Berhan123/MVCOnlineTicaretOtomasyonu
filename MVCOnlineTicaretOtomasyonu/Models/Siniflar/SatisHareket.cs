using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCOnlineTicaretOtomasyonu.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int Satisid { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public Decimal Fiyat { get; set; }
        public Decimal Toplam { get; set; }


        public virtual Urun Urun { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }

    }
}