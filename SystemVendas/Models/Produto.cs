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
        [Display(Name ="Produto")]
        public int  idProduto { get; set; }

        [Display(Name = "Nome")]
        public string nomeProduto { get; set; }

        [Display(Name = "Preço")]
        public double precoProduto { get; set; }

        [Display(Name = "Estoque")]
        public double estoque { get; set; }

        public int IdCategoria { get; set; }

        //mapear chave estrangeira
        [ForeignKey("IdCategoria")]
        public virtual Categoria categoria { get; set; }

        
    }
}