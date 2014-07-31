namespace YahooFantasy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KickerStats : DbMigration
    {
        public override void Up()
        {
			AddColumn("dbo.SimpleStats", "MadeFieldGoals_Zero", c => c.Int());
			AddColumn("dbo.SimpleStats", "MadeFieldGoals_Twenty", c => c.Int());
			AddColumn("dbo.SimpleStats", "MadeFieldGoals_Thirty", c => c.Int());
			AddColumn("dbo.SimpleStats", "MadeFieldGoals_Forty", c => c.Int());
			AddColumn("dbo.SimpleStats", "MadeFieldGoals_Fifty", c => c.Int());
			AddColumn("dbo.SimpleStats", "MissedFieldGoals_Zero", c => c.Int());
			AddColumn("dbo.SimpleStats", "MissedFieldGoals_Twenty", c => c.Int());
			AddColumn("dbo.SimpleStats", "MissedFieldGoals_Thirty", c => c.Int());
			AddColumn("dbo.SimpleStats", "MissedFieldGoals_Forty", c => c.Int());
			AddColumn("dbo.SimpleStats", "MissedFieldGoals_Fifty", c => c.Int());
			AddColumn("dbo.SimpleStats", "ExtraPointsMade", c => c.Int());
			AddColumn("dbo.SimpleStats", "ExtraPointsMissed", c => c.Int());            
        }
        
        public override void Down()
        {
			DropColumn("dbo.SimpleStats", "MadeFieldGoals_Zero");
			DropColumn("dbo.SimpleStats", "MadeFieldGoals_Twenty");
			DropColumn("dbo.SimpleStats", "MadeFieldGoals_Thirty");
			DropColumn("dbo.SimpleStats", "MadeFieldGoals_Forty");
			DropColumn("dbo.SimpleStats", "MadeFieldGoals_Fifty");
			DropColumn("dbo.SimpleStats", "MissedFieldGoals_Zero");
			DropColumn("dbo.SimpleStats", "MissedFieldGoals_Twenty");
			DropColumn("dbo.SimpleStats", "MissedFieldGoals_Thirty");
			DropColumn("dbo.SimpleStats", "MissedFieldGoals_Forty");
			DropColumn("dbo.SimpleStats", "MissedFieldGoals_Fifty");
			DropColumn("dbo.SimpleStats", "ExtraPointsMade");
			DropColumn("dbo.SimpleStats", "ExtraPointsMissed");
        }
    }
}
