using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Gönderici { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Alıcı { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Konu { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(2000)]
        public string İçerik { get; set; }

        public DateTime Tarih { get; set; }
    }
}