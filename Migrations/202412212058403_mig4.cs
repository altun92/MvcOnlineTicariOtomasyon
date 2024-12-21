namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personels", "PersonelUnvan", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.Personels", "PersonelTel", c => c.String(maxLength: 11, unicode: false));
            AddColumn("dbo.Personels", "PersonelAdres", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personels", "PersonelAdres");
            DropColumn("dbo.Personels", "PersonelTel");
            DropColumn("dbo.Personels", "PersonelUnvan");
        }
    }
}
