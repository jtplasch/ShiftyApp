namespace ShiftyApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Requests", "EmployeeId");
            CreateIndex("dbo.WorkSchedule", "EmployeeId");
            AddForeignKey("dbo.Requests", "EmployeeId", "dbo.Employee", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.WorkSchedule", "EmployeeId", "dbo.Employee", "EmployeeId", cascadeDelete: true);
            DropColumn("dbo.Employee", "RequestId");
            DropColumn("dbo.Employee", "DateWorkingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "DateWorkingId", c => c.Int(nullable: false));
            AddColumn("dbo.Employee", "RequestId", c => c.Int(nullable: false));
            DropForeignKey("dbo.WorkSchedule", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Requests", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.WorkSchedule", new[] { "EmployeeId" });
            DropIndex("dbo.Requests", new[] { "EmployeeId" });
        }
    }
}
