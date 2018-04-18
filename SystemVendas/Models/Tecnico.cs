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
        public int IdTecnico { get; set; }
        public string NomeDotecnico { get; set; }
        public string TelefoneTecnico { get; set; }
        public string EmailTecnico { get; set; }
    }
}