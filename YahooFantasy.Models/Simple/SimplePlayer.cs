using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Models.Simple
{
	public enum SimplePlayerTypes
	{
		OffensivePlayer,
		Kicker,
		TeamDefense,
		DefensivePlayer
	}

	public enum SimplePositionTypes
	{
		Quarterback,
		Runningback,
		Receiver,
		TightEnd,
		Kicker,
		DefensivePlayer,
		TeamDefense
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
	}
}
