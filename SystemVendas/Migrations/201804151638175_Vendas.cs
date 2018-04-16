namespace SystemVendas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vendas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Venda",
                c => new
                    {
                        IdVenda = c.Int(nullable: false, identity: true),
                        IdProduto = c.Int(nullable: false),
                        IdVendedor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdVenda)
                .ForeignKey("dbo.Produto", t => t.IdProduto, cascadeDelete: true)
                .ForeignKey("dbo.Vendedor", t => t.IdVendedor, cascadeDelete: true)
                .Index(t => t.IdProduto)
                .Index(t => t.IdVendedor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Venda", "IdVendedor", "dbo.Vendedor");
            DropForeignKey("dbo.Venda", "IdProduto", "dbo.Produto");
            DropIndex("dbo.Venda", new[] { "IdVendedor" });
            DropIndex("dbo.Venda", new[] { "IdProduto" });
            DropTable("dbo.Venda");
        }
    }
}
