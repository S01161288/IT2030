namespace StudentEnrollment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollments", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enrollments", "Notes");
        }
    }
}
