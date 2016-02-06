namespace Pickin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequireEmailAddress : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PickinUsers", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PickinUsers", "Email", c => c.String(nullable: false));
        }
    }
}
