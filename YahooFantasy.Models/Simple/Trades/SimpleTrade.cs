using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace YahooFantasy.Models.Simple.Trades
{
	public class SimpleTrade
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string LeagueName { get; set; }

		public string UserName { get; set; }

		public virtual ICollection<SimplePlayer> PlayersTradedOut { get; set; }

		public virtual ICollection<SimplePlayer> PlayersTradedIn { get; set; }

		public DateTime? ExecutedAt { get; set; }

		public DateTime? CreatedAt { get; set; }

		[Column(TypeName = "ntext")]
		public string TransactionJson { get; set; }
	}
}