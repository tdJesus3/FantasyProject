namespace YahooFantasy.Models.Simple
{
	public class LeagueRules
	{
		public int Id { get; set; }

		public bool HasStandardScoring { get; set; }

		public bool HasPpr { get; set; }

		public bool HasSixPointPassingTds { get; set; }
	}
}