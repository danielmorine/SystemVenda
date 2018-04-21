using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVendas.Models
{
    public class Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }

        [Display(Name = "Empresa")]
        public string NomeEmpresa { get; set; }

        [Display(Name = "Email")]
        public string EmailEmpresa { get; set; }

        [Display(Name = "Telefone")]
        public string TelefoneEmpresa { get; set; }

        [Display(Name = "Responsável")]
        public string Responsavel { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
    }
}