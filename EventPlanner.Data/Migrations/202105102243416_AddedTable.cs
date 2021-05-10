namespace EventPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "EventId", "dbo.Event");
            DropIndex("dbo.Customer", new[] { "EventId" });
            CreateTable(
                "dbo.EventCustomer",
                c => new
                    {
                        Event_EventId = c.Int(nullable: false),
                        Customer_CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_EventId, t.Customer_CustomerId })
                .ForeignKey("dbo.Event", t => t.Event_EventId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.Customer_CustomerId, cascadeDelete: true)
                .Index(t => t.Event_EventId)
                .Index(t => t.Customer_CustomerId);
            
            DropColumn("dbo.Customer", "EventId");
            DropColumn("dbo.Customer", "EventTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "EventTitle", c => c.String());
            AddColumn("dbo.Customer", "EventId", c => c.Int(nullable: false));
            DropForeignKey("dbo.EventCustomer", "Customer_CustomerId", "dbo.Customer");
            DropForeignKey("dbo.EventCustomer", "Event_EventId", "dbo.Event");
            DropIndex("dbo.EventCustomer", new[] { "Customer_CustomerId" });
            DropIndex("dbo.EventCustomer", new[] { "Event_EventId" });
            DropTable("dbo.EventCustomer");
            CreateIndex("dbo.Customer", "EventId");
            AddForeignKey("dbo.Customer", "EventId", "dbo.Event", "EventId", cascadeDelete: true);
        }
    }
}
