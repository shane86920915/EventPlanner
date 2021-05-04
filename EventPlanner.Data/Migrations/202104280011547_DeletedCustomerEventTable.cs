namespace EventPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedCustomerEventTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "EventTitle", c => c.String());
            CreateIndex("dbo.Customer", "EventId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customer", new[] { "EventId" });
            DropColumn("dbo.Customer", "EventTitle");
        }
    }
}
