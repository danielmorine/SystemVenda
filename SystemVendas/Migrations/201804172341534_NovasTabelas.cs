namespace SystemVendas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovasTabelas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chamado",
                c => new
                    {
                        IdChamado = c.Int(nullable: false, identity: true),
                        IdTecnico = c.Int(nullable: false),
                        IdEmpresa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdChamado)
                .ForeignKey("dbo.Empresa", t => t.IdEmpresa, cascadeDelete: true)
                .ForeignKey("dbo.Tecnico", t => t.IdTecnico, cascadeDelete: true)
                .Index(t => t.IdTecnico)
                .Index(t => t.IdEmpresa);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        IdEmpresa = c.Int(nullable: false, identity: true),
                        NomeEmpresa = c.String(),
                        EmailEmpresa = c.String(),
                        TelefoneEmpresa = c.String(),
                        Responsavel = c.String(),
                        Endereco = c.String(),
                    })
                .PrimaryKey(t => t.IdEmpresa);
            
            CreateTable(
                "dbo.Tecnico",
                c => new
                    {
                        IdTecnico = c.Int(nullable: false, identity: true),
                        NomeDotecnico = c.String(),
                        TelefoneTecnico = c.String(),
                        EmailTecnico = c.String(),
                    })
                .PrimaryKey(t => t.IdTecnico);
            
            AlterColumn("dbo.Produto", "precoProduto", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chamado", "IdTecnico", "dbo.Tecnico");
            DropForeignKey("dbo.Chamado", "IdEmpresa", "dbo.Empresa");
            DropIndex("dbo.Chamado", new[] { "IdEmpresa" });
            DropIndex("dbo.Chamado", new[] { "IdTecnico" });
            AlterColumn("dbo.Produto", "precoProduto", c => c.String());
            DropTable("dbo.Tecnico");
            DropTable("dbo.Empresa");
            DropTable("dbo.Chamado");
        }
    }
}
