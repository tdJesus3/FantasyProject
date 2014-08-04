using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFantasy.Models.Simple;

namespace YahooFantasy.Data
{
	public class FantasyContext : DbContext
	{
		public FantasyContext() : base("FantasyContext") { }

		public DbSet<SimplePlayer> Players { get; set; }

		public DbSet<SimpleStats> Stats { get; set; }

		public DbSet<NoStats> NoStats { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
