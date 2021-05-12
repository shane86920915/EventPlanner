namespace EventPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intionalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventCustomer",
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
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        CustomerFName = c.String(nullable: false),
                        CustomerLName = c.String(nullable: false),
                        CustomerMInitial = c.String(maxLength: 1),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        EventTitle = c.String(nullable: false, maxLength: 70),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.EventId);
            
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
            
            CreateTable(
                "dbo.Sponsor",
                c => new
                    {
                        SponsorId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        SponsorsName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.SponsorId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Speaker",
                c => new
                    {
                        SpeakerId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        SpeakerFName = c.String(nullable: false),
                        SpeakerLName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.SpeakerId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.EventCustomer1",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.EventSpeaker", "Speaker_SpeakerId", "dbo.Speaker");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.EventCustomer", "EventId", "dbo.Event");
            DropForeignKey("dbo.EventCustomer", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.EventSponsor", "SponsorId", "dbo.Sponsor");
            DropForeignKey("dbo.EventSponsor", "EventId", "dbo.Event");
            DropForeignKey("dbo.EventSpeaker", "EventId", "dbo.Event");
            DropForeignKey("dbo.EventSpeaker", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.EventCustomer1", "Customer_CustomerId", "dbo.Customer");
            DropForeignKey("dbo.EventCustomer1", "Event_EventId", "dbo.Event");
            DropIndex("dbo.EventCustomer1", new[] { "Customer_CustomerId" });
            DropIndex("dbo.EventCustomer1", new[] { "Event_EventId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.EventSponsor", new[] { "SponsorId" });
            DropIndex("dbo.EventSponsor", new[] { "EventId" });
            DropIndex("dbo.EventSpeaker", new[] { "Speaker_SpeakerId" });
            DropIndex("dbo.EventSpeaker", new[] { "CustomerId" });
            DropIndex("dbo.EventSpeaker", new[] { "EventId" });
            DropIndex("dbo.EventCustomer", new[] { "EventId" });
            DropIndex("dbo.EventCustomer", new[] { "CustomerId" });
            DropTable("dbo.EventCustomer1");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Speaker");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Sponsor");
            DropTable("dbo.EventSponsor");
            DropTable("dbo.EventSpeaker");
            DropTable("dbo.Event");
            DropTable("dbo.Customer");
            DropTable("dbo.EventCustomer");
        }
    }
}
