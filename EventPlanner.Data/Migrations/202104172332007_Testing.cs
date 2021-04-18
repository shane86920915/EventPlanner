namespace EventPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Event", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Sponsor", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Speaker", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Speaker", "OwnerId");
            DropColumn("dbo.Sponsor", "OwnerId");
            DropColumn("dbo.Event", "OwnerId");
            DropColumn("dbo.Customer", "OwnerId");
        }
    }
}
