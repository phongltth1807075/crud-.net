namespace PhatT1808A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDatabasePhat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassLates",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Date = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClassLates");
        }
    }
}
