using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using YahooFantasy.Models.Simple;

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

		public DbSet<SimpleTrade> Trades { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}