namespace YahooFantasy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.League",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeagueKey = c.String(),
                        CreatedBy = c.String(),
                        PointsPerReception = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PointsPerPassingTouchdown = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumberOfOwners = c.Int(nullable: false),
                        LeagueJson = c.String(storeType: "ntext"),
                        SettingsJson = c.String(storeType: "ntext"),
                        TransactionsJson = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SimpleTrade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeagueName = c.String(),
                        UserName = c.String(),
                        ExecutedAt = c.DateTime(),
                        CreatedAt = c.DateTime(),
                        TransactionJson = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TradedIn",
                c => new
                    {
                        PlayerId = c.Int(nullable: false),
                        TradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayerId, t.TradeId })
                .ForeignKey("dbo.SimpleTrade", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.SimplePlayer", t => t.TradeId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.TradeId);
            
            CreateTable(
                "dbo.TradedOut",
                c => new
                    {
                        PlayerId = c.Int(nullable: false),
                        TradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayerId, t.TradeId })
                .ForeignKey("dbo.SimpleTrade", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.SimplePlayer", t => t.TradeId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.TradeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TradedOut", "TradeId", "dbo.SimplePlayer");
            DropForeignKey("dbo.TradedOut", "PlayerId", "dbo.SimpleTrade");
            DropForeignKey("dbo.TradedIn", "TradeId", "dbo.SimplePlayer");
            DropForeignKey("dbo.TradedIn", "PlayerId", "dbo.SimpleTrade");
            DropIndex("dbo.TradedOut", new[] { "TradeId" });
            DropIndex("dbo.TradedOut", new[] { "PlayerId" });
            DropIndex("dbo.TradedIn", new[] { "TradeId" });
            DropIndex("dbo.TradedIn", new[] { "PlayerId" });
            DropTable("dbo.TradedOut");
            DropTable("dbo.TradedIn");
            DropTable("dbo.SimpleTrade");
            DropTable("dbo.League");
        }
    }
}
