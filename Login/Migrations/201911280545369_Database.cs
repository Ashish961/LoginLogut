namespace Login.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginCredentials",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        userEmail = c.String(),
                        userPassword = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoginCredentials");
        }
    }
}
