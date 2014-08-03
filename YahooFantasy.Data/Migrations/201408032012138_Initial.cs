namespace YahooFantasy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SimplePlayer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YahooPlayerId = c.Int(nullable: false),
                        FullName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UniformNumber = c.String(),
                        PlayerType = c.Int(nullable: false),
                        PrimaryPosition = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SimpleStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.DateTime(nullable: false),
                        Week = c.Int(),
                        GamesPlayed = c.Int(),
                        TeamName = c.String(),
                        TeamAbbreviation = c.String(),
                        Position = c.Int(nullable: false),
                        FumblesLost = c.Int(nullable: false),
                        RushingAttempts = c.Int(nullable: false),
                        RushingYards = c.Int(nullable: false),
                        RushingTouchdowns = c.Int(nullable: false),
                        TwoPointConversions = c.Int(nullable: false),
                        PassingAttempts = c.Int(nullable: false),
                        Completions = c.Int(nullable: false),
                        IncompletePasses = c.Int(nullable: false),
                        PassingYards = c.Int(nullable: false),
                        PassingTouchdowns = c.Int(nullable: false),
                        Interceptions = c.Int(nullable: false),
                        Sacks = c.Int(nullable: false),
                        Receptions = c.Int(nullable: false),
                        ReceivingYards = c.Int(nullable: false),
                        ReceivingTouchdowns = c.Int(nullable: false),
                        ReturnYards = c.Int(nullable: false),
                        ReturnTouchdowns = c.Int(nullable: false),
                        MadeFieldGoals_Zero = c.Int(nullable: false),
                        MadeFieldGoals_Twenty = c.Int(nullable: false),
                        MadeFieldGoals_Thirty = c.Int(nullable: false),
                        MadeFieldGoals_Forty = c.Int(nullable: false),
                        MadeFieldGoals_Fifty = c.Int(nullable: false),
                        MissedFieldGoals_Zero = c.Int(nullable: false),
                        MissedFieldGoals_Twenty = c.Int(nullable: false),
                        MissedFieldGoals_Thirty = c.Int(nullable: false),
                        MissedFieldGoals_Forty = c.Int(nullable: false),
                        MissedFieldGoals_Fifty = c.Int(nullable: false),
                        ExtraPointsMade = c.Int(nullable: false),
                        ExtraPointsMissed = c.Int(nullable: false),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SimplePlayer", t => t.Player_Id)
                .Index(t => t.Player_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SimpleStats", "Player_Id", "dbo.SimplePlayer");
            DropIndex("dbo.SimpleStats", new[] { "Player_Id" });
            DropTable("dbo.SimpleStats");
            DropTable("dbo.SimplePlayer");
        }
    }
}
