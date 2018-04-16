namespace SystemVendas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false, identity: true),
                        nomeCategoria = c.String(),
                    })
                .PrimaryKey(t => t.IdCategoria);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        idProduto = c.Int(nullable: false, identity: true),
                        nomeProduto = c.String(),
                        precoProduto = c.String(),
                        IdCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idProduto)
                .ForeignKey("dbo.Categoria", t => t.IdCategoria, cascadeDelete: true)
                .Index(t => t.IdCategoria);
            
            CreateTable(
                "dbo.Vendedor",
                c => new
                    {
                        idVendedor = c.Int(nullable: false, identity: true),
                        nomeVendedor = c.String(),
                    })
                .PrimaryKey(t => t.idVendedor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "IdCategoria", "dbo.Categoria");
            DropIndex("dbo.Produto", new[] { "IdCategoria" });
            DropTable("dbo.Vendedor");
            DropTable("dbo.Produto");
            DropTable("dbo.Categoria");
        }
    }
}
