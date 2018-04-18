using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using SystemVendas.Models;

namespace SystemVendas.RepositoryEF
{
    public class EFContext : DbContext
    {
        public EFContext() : base("BaseContexto") { }

        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Produto> produtos { get; set; }
        public DbSet<Vendedor> vendedores { get; set; }
        
        public DbSet<Venda> vendas { get; set; }

        public DbSet<Tecnico> tecnicos { get; set; }
        public DbSet<Empresa> empresas { get; set; }
        public DbSet<Chamado> chamados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }


    }
}