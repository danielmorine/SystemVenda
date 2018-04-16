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
        public int IdCategoria { get; set; }
        public string nomeCategoria { get; set; }
    }
}