namespace EventPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPriceToEvent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Speaker", "EventId", "dbo.Event");
            DropForeignKey("dbo.Ticket", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Ticket", "EventId", "dbo.Event");
            DropIndex("dbo.Speaker", new[] { "EventId" });
            DropIndex("dbo.Ticket", new[] { "CustomerId" });
            DropIndex("dbo.Ticket", new[] { "EventId" });
            CreateTable(
                "dbo.EventSpeaker",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Speaker_SpeakerId = c.Int(),
                    })
                .PrimaryKey(t => new { t.EventId, t.CustomerId })
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Speaker", t => t.Speaker_SpeakerId)
                .Index(t => t.EventId)
                .Index(t => t.CustomerId)
                .Index(t => t.Speaker_SpeakerId);
            
            CreateTable(
                "dbo.EventSponsor",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        SponsorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventId, t.SponsorId })
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Sponsor", t => t.SponsorId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.SponsorId);
            
            AddColumn("dbo.Customer", "CustomerFName", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "CustomerLName", c => c.String(nullable: false));
            AddColumn("dbo.Event", "EventTitle", c => c.String(nullable: false));
            AddColumn("dbo.Event", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Speaker", "SpeakerFName", c => c.String(nullable: false));
            AddColumn("dbo.Speaker", "SpeakerLName", c => c.String(nullable: false));
            DropColumn("dbo.Customer", "FirstName");
            DropColumn("dbo.Customer", "Lastname");
            DropColumn("dbo.Event", "Title");
            DropColumn("dbo.Speaker", "EventId");
            DropColumn("dbo.Speaker", "FirstName");
            DropColumn("dbo.Speaker", "Lastname");
            DropTable("dbo.Ticket");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.TicketId);
            
            AddColumn("dbo.Speaker", "Lastname", c => c.String(nullable: false));
            AddColumn("dbo.Speaker", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Speaker", "EventId", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "Lastname", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "FirstName", c => c.String(nullable: false));
            DropForeignKey("dbo.EventSpeaker", "Speaker_SpeakerId", "dbo.Speaker");
            DropForeignKey("dbo.EventSponsor", "SponsorId", "dbo.Sponsor");
            DropForeignKey("dbo.EventSponsor", "EventId", "dbo.Event");
            DropForeignKey("dbo.EventSpeaker", "EventId", "dbo.Event");
            DropForeignKey("dbo.EventSpeaker", "CustomerId", "dbo.Customer");
            DropIndex("dbo.EventSponsor", new[] { "SponsorId" });
            DropIndex("dbo.EventSponsor", new[] { "EventId" });
            DropIndex("dbo.EventSpeaker", new[] { "Speaker_SpeakerId" });
            DropIndex("dbo.EventSpeaker", new[] { "CustomerId" });
            DropIndex("dbo.EventSpeaker", new[] { "EventId" });
            DropColumn("dbo.Speaker", "SpeakerLName");
            DropColumn("dbo.Speaker", "SpeakerFName");
            DropColumn("dbo.Event", "Price");
            DropColumn("dbo.Event", "EventTitle");
            DropColumn("dbo.Customer", "CustomerLName");
            DropColumn("dbo.Customer", "CustomerFName");
            DropTable("dbo.EventSponsor");
            DropTable("dbo.EventSpeaker");
            CreateIndex("dbo.Ticket", "EventId");
            CreateIndex("dbo.Ticket", "CustomerId");
            CreateIndex("dbo.Speaker", "EventId");
            AddForeignKey("dbo.Ticket", "EventId", "dbo.Event", "EventId", cascadeDelete: true);
            AddForeignKey("dbo.Ticket", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Speaker", "EventId", "dbo.Event", "EventId", cascadeDelete: true);
        }
    }
}
