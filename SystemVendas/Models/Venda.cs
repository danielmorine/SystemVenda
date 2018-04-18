using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemVendas.Models
{
    public class Venda
    {
        [Key]
        public int IdVenda { get; set; }

        public int IdProduto { get; set; }
        public int IdVendedor { get; set; }

        

        [ForeignKey("IdProduto")]
        public virtual Produto produtos {get; set;}

        [ForeignKey("IdVendedor")]
        public virtual Vendedor vendedores { get; set; }
    }
}