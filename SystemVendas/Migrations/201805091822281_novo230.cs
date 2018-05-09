namespace SystemVendas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novo230 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chamado", "Problema", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chamado", "Problema");
        }
    }
}
