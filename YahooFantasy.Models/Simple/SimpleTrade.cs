using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace YahooFantasy.Models.Simple
{
	public class SimpleTrade
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string LeagueName { get; set; }

		public string UserName { get; set; }

		public virtual ICollection<SimplePlayer> TradedOut { get; set; }

		public virtual ICollection<SimplePlayer> TradedIn { get; set; }

		public DateTime? ExecutedAt { get; set; }

		public DateTime? CreatedAt { get; set; }
	}
}