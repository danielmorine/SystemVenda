using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVendas.Models
{
    public class Categoria
    { 
        [Key]
        [Display(Name = "Código")]
        public int IdCategoria { get; set; }

        [Display(Name = "Categoria")]
        public string nomeCategoria { get; set; }
    }
}