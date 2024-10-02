using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int CariId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage ="Cari Adı 30 Karakterden Fazla Olamaz..")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız..")]
        public string CariAd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "Cari Adı 30 Karakterden Fazla Olamaz..")]
        [Required(ErrorMessage ="Bu alanı boş bırakamazsınız..")]
        public string CariSoyad { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(13, ErrorMessage = "Cari Adı 13 Karakterden Fazla Olamaz..")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız..")]
        public string CariSehir { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50, ErrorMessage = "Cari Adı 50 Karakterden Fazla Olamaz..")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız..")]
        public string CariMail { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}