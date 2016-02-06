namespace Pickin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequireRealUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PickinUsers", "RealUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PickinUsers", new[] { "RealUser_Id" });
            AlterColumn("dbo.PickinUsers", "RealUser_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.PickinUsers", "RealUser_Id");
            AddForeignKey("dbo.PickinUsers", "RealUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PickinUsers", "RealUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PickinUsers", new[] { "RealUser_Id" });
            AlterColumn("dbo.PickinUsers", "RealUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.PickinUsers", "RealUser_Id");
            AddForeignKey("dbo.PickinUsers", "RealUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
