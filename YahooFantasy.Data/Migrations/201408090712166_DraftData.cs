namespace YahooFantasy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DraftData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adp",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(),
                        Position = c.String(),
                        Team = c.String(),
                        TimesDrafted = c.Int(nullable: false),
                        OverallAdp = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Adp");
        }
    }
}
