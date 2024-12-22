using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }

        [Display(Name = "Personel Adı")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }

        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }

        [Display(Name = "Profil Fotoğrafı")]
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }

        [Display(Name = "Personel Ünvanı")]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string PersonelUnvan {  get; set; }

        [Display(Name = "Personel Telefonu")]
        [Column(TypeName = "varchar")]
        [StringLength(11)]
        public string PersonelTel { get; set; }

        [Display(Name = "Personel Adresi")]
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string PersonelAdres { get; set; }
    }
}