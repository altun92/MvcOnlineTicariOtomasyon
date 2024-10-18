namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faturalars", "Saat", c => c.String(maxLength: 5, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Faturalars", "Saat");
        }
    }
}
