using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemVendas.Models
{
    public class Chamado
    {
        [Key]
        public int IdChamado { get; set; }

        public int IdTecnico { get; set; }
        public int IdEmpresa { get; set; }
        
        public string Problema { get; set; }

        [ForeignKey("IdTecnico")]
        public virtual Tecnico tecnicos { get; set; }

        [ForeignKey("IdEmpresa")]
        public virtual Empresa empresas { get; set; }
    }
}