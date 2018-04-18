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

        public string NomeEmpresa { get; set; }
        public string EmailEmpresa { get; set; }
        public string TelefoneEmpresa { get; set; }
        public string Responsavel { get; set; }
        public string Endereco { get; set; }
    }
}