namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Role", newName: "AspNetRoles");
            RenameTable(name: "dbo.UserRole", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.UserClaim", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.UserLogin", newName: "AspNetUserLogins");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AspNetUserLogins", newName: "UserLogin");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "UserClaim");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "UserRole");
            RenameTable(name: "dbo.AspNetRoles", newName: "Role");
        }
    }
}
