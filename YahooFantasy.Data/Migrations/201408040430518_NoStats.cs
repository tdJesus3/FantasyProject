namespace YahooFantasy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoStats : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NoStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Week = c.Int(nullable: false),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SimplePlayer", t => t.Player_Id)
                .Index(t => t.Player_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NoStats", "Player_Id", "dbo.SimplePlayer");
            DropIndex("dbo.NoStats", new[] { "Player_Id" });
            DropTable("dbo.NoStats");
        }
    }
}
