namespace Pickin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequireEmailAddress : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PickinUsers", "FirstName", c => c.String());
            AlterColumn("dbo.PickinUsers", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PickinUsers", "Email", c => c.String());
            AlterColumn("dbo.PickinUsers", "FirstName", c => c.String(nullable: false));
        }
    }
}
