namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alllength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KargoDetays", "TakipKodu", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.KargoDetays", "Alici", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KargoDetays", "Alici", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.KargoDetays", "TakipKodu", c => c.String(maxLength: 10, unicode: false));
        }
    }
}
