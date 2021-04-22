namespace EventPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDataAnnotationForEvent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Event", "EventTitle", c => c.String(nullable: false, maxLength: 70));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Event", "EventTitle", c => c.String(nullable: false));
        }
    }
}
