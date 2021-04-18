namespace EventPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedMiddleInitialToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "CustomerMInitial", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "CustomerMInitial");
        }
    }
}
