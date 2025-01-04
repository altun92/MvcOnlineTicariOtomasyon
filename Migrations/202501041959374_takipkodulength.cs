namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class takipkodulength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KargoDetays", "Personel", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KargoDetays", "Personel", c => c.String(maxLength: 10, unicode: false));
        }
    }
}
