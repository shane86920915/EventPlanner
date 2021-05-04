namespace EventPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testing2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "EventId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "EventId");
        }
    }
}
