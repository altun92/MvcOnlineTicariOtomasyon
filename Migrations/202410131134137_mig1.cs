namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Faturalars", "Saat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Faturalars", "Saat", c => c.DateTime(nullable: false));
        }
    }
}
