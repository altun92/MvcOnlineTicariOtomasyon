namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mesajlars",
                c => new
                    {
                        MesajId = c.Int(nullable: false, identity: true),
                        Gönderici = c.String(maxLength: 50, unicode: false),
                        Alıcı = c.String(maxLength: 50, unicode: false),
                        Konu = c.String(maxLength: 30, unicode: false),
                        İçerik = c.String(maxLength: 2000, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MesajId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mesajlars");
        }
    }
}
