using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVendas.Models
{
    public class Tecnico
    {
        [Key]
        [Display(Name = "Técnico")]
        public int IdTecnico { get; set; }
        [Display(Name = "Nome")]
        public string NomeDotecnico { get; set; }
        [Display(Name = "Telefone")]
        public string TelefoneTecnico { get; set; }
        [Display(Name = "Email")]
        public string EmailTecnico { get; set; }
    }
}