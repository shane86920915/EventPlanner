namespace EventPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCustomerEventToDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerEvent", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerEvent", "OwnerId");
        }
    }
}
