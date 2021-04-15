namespace ShiftyApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAfterAllTablesBuilt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Requests", "Date", c => c.String(nullable: false));
            AlterColumn("dbo.WorkSchedule", "Date", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkSchedule", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Requests", "Date", c => c.DateTime(nullable: false));
        }
    }
}
