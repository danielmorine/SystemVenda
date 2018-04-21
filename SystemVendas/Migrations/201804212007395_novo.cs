namespace SystemVendas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "estoque", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produto", "estoque");
        }
    }
}
