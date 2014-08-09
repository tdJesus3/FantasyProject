namespace YahooFantasy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DraftStartDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adp", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adp", "Year");
        }
    }
}
