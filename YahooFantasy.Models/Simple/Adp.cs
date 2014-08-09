using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Models.Simple
{
	public class Adp
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string PlayerName { get; set; }

		public string Position { get; set; }

		public string Team { get; set; }

		public int TimesDrafted { get; set; }

		public decimal OverallAdp { get; set; }

		public int Year { get; set; }
	}
}
