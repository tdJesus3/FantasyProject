using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFantasy.Models.Simple.Trades;

namespace YahooFantasy.Models.Simple
{
	public enum SimplePlayerTypes
	{
		Unknown = 0,
		OffensivePlayer = 1,
		Kicker = 2,
		TeamDefense = 3,
		DefensivePlayer = 4
	}

	public enum SimplePositionTypes
	{
		Unknown = 0,
		Quarterback = 1,
		Runningback = 2,
		Receiver = 3,
		TightEnd = 4,
		Kicker = 5,
		TeamDefense = 6,
		Cornerback = 7,
		DefensiveTackle = 8,
		Safety = 9,
		Linebacker = 10,
		DefensiveEnd = 11
	}

	public class SimplePlayer
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int YahooPlayerId { get; set; }

		public string FullName { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string UniformNumber { get; set; }

		public SimplePlayerTypes PlayerType { get; set; }

		public SimplePositionTypes PrimaryPosition { get; set; }

		public virtual ICollection<SimpleStats> Stats { get; set; }

		public virtual ICollection<SimpleTrade> TradesIn { get; set; }

		public virtual ICollection<SimpleTrade> TradesOut { get; set; }
	}
}
