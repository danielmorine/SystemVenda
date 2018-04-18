using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemVendas.Models
{
    public class Produto
    {
        [Key]
        public int  idProduto { get; set; }
        public string nomeProduto { get; set; }
        public double precoProduto { get; set; }
        public int IdCategoria { get; set; }

        //mapear chave estrangeira
        [ForeignKey("IdCategoria")]
        public virtual Categoria categoria { get; set; }

        
    }
}