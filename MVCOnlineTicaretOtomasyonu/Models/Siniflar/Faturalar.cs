using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicaretOtomasyonu.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int Faturaid { get; set; }

        [Column(TypeName = "Char"), StringLength(1)]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "Varchar"), StringLength(6)]
        public string FaturaSıraNo { get; set; }
        public DateTime Tarih { get; set; }

        [Column(TypeName = "Varchar"), StringLength(60)]
        public string VerigiDairesi { get; set; }


        [Column(TypeName = "Varchar"), StringLength(5)]
        public string Saat { get; set; }

        [Column(TypeName = "Varchar"), StringLength(30)]
        public string TeslimEden { get; set; }

        [Column(TypeName = "Varchar"), StringLength(30)]
        public string TeslimAlan { get; set; }

        public Decimal Toplam { get; set; }


        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}