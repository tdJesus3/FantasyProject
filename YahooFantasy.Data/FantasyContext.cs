using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using YahooFantasy.Models.Simple;
using YahooFantasy.Models.Simple.Trades;

namespace YahooFantasy.Data
{
	public class FantasyContext : DbContext
	{
		public FantasyContext()
			: base("FantasyContext")
		{
		}

		public DbSet<SimplePlayer> Players { get; set; }

		public DbSet<SimpleStats> Stats { get; set; }

		public DbSet<NoStats> NoStats { get; set; }

		public DbSet<Adp> Drafts { get; set; }

		public DbSet<League> Leagues { get; set; }

		public DbSet<SimpleTrade> Trades { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Entity<SimpleTrade>()
				.HasMany(t => t.PlayersTradedIn)
				.WithMany(p => p.TradesIn)
				.Map(m =>
				{
					m.ToTable("TradedIn");
					m.MapLeftKey("PlayerId");
					m.MapRightKey("TradeId");
				});

			modelBuilder.Entity<SimpleTrade>()
				.HasMany(t => t.PlayersTradedOut)
				.WithMany(p => p.TradesOut)
				.Map(m =>
				{
					m.ToTable("TradedOut");
					m.MapLeftKey("PlayerId");
					m.MapRightKey("TradeId");
				});
		}
	}
}