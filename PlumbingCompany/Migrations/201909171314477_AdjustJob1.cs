namespace PlumbingCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustJob1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Details", c => c.String());
            AddColumn("dbo.Jobs", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Location");
            DropColumn("dbo.Jobs", "Details");
        }
    }
}
