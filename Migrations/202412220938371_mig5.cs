namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoLists",
                c => new
                    {
                        ToDoListId = c.Int(nullable: false, identity: true),
                        Başlik = c.String(maxLength: 100, unicode: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ToDoListId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ToDoLists");
        }
    }
}
