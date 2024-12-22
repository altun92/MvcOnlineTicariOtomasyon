using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class ToDoList
    {
        [Key]
        public int ToDoListId { get; set; }
        [Column (TypeName="varchar")]
        [StringLength(100)]
        public string Başlik { get; set; }
        public bool Durum { get; set; }
    }
}