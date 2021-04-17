namespace EventPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCustomerEvent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Event", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Event", new[] { "CustomerId" });
            CreateTable(
                "dbo.CustomerEvent",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.EventId })
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.EventId);
            
            AddColumn("dbo.Sponsor", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Sponsor", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.Event", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.CustomerEvent", "EventId", "dbo.Event");
            DropForeignKey("dbo.CustomerEvent", "CustomerId", "dbo.Customer");
            DropIndex("dbo.CustomerEvent", new[] { "EventId" });
            DropIndex("dbo.CustomerEvent", new[] { "CustomerId" });
            DropColumn("dbo.Sponsor", "ModifiedUtc");
            DropColumn("dbo.Sponsor", "CreatedUtc");
            DropTable("dbo.CustomerEvent");
            CreateIndex("dbo.Event", "CustomerId");
            AddForeignKey("dbo.Event", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
        }
    }
}
