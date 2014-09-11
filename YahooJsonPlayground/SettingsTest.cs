using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooJsonPlayground
{

	public class Rootobject
	{
		[JsonProperty("fantasy_content")]
		public FantasyContent FantasyContent { get; set; }

	}
	public class FantasyContent
	{
		[JsonProperty("xmllang")]
		public string Xmllang { get; set; }

		[JsonProperty("yahoouri")]
		public string Yahoouri { get; set; }

		[JsonProperty("league")]
		public LeagueTest[] League { get; set; }

		[JsonProperty("time")]
		public string Time { get; set; }

		[JsonProperty("copyright")]
		public string Copyright { get; set; }

		[JsonProperty("refresh_rate")]
		public string RefreshRate { get; set; }

	}
	public class LeagueTest
	{
		[JsonProperty("league_key")]
		public string LeagueKey { get; set; }

		[JsonProperty("league_id")]
		public string LeagueId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("draft_status")]
		public string DraftStatus { get; set; }

		[JsonProperty("num_teams")]
		public int NumTeams { get; set; }

		[JsonProperty("edit_key")]
		public int EditKey { get; set; }

		[JsonProperty("weekly_deadline")]
		public string WeeklyDeadline { get; set; }

		[JsonProperty("league_update_timestamp")]
		public string LeagueUpdateTimestamp { get; set; }

		[JsonProperty("scoring_type")]
		public string ScoringType { get; set; }

		[JsonProperty("league_type")]
		public string LeagueType { get; set; }

		[JsonProperty("renew")]
		public string Renew { get; set; }

		[JsonProperty("renewed")]
		public string Renewed { get; set; }

		[JsonProperty("short_invitation_url")]
		public string ShortInvitationUrl { get; set; }

		[JsonProperty("is_pro_league")]
		public string IsProLeague { get; set; }

		[JsonProperty("current_week")]
		public int CurrentWeek { get; set; }

		[JsonProperty("start_week")]
		public string StartWeek { get; set; }

		[JsonProperty("start_date")]
		public string StartDate { get; set; }

		[JsonProperty("end_week")]
		public string EndWeek { get; set; }

		[JsonProperty("end_date")]
		public string EndDate { get; set; }

		[JsonProperty("settings")]
		public Setting[] Settings { get; set; }

	}
	public class Setting
	{
		[JsonProperty("draft_type")]
		public string DraftType { get; set; }

		[JsonProperty("is_auction_draft")]
		public string IsAuctionDraft { get; set; }

		[JsonProperty("scoring_type")]
		public string ScoringType { get; set; }

		[JsonProperty("uses_playoff")]
		public string UsesPlayoff { get; set; }

		[JsonProperty("has_playoff_consolation_games")]
		public bool HasPlayoffConsolationGames { get; set; }

		[JsonProperty("playoff_start_week")]
		public string PlayoffStartWeek { get; set; }

		[JsonProperty("uses_playoff_reseeding")]
		public int UsesPlayoffReseeding { get; set; }

		[JsonProperty("uses_lock_eliminated_teams")]
		public int UsesLockEliminatedTeams { get; set; }

		[JsonProperty("num_playoff_teams")]
		public string NumPlayoffTeams { get; set; }

		[JsonProperty("num_playoff_consolation_teams")]
		public int NumPlayoffConsolationTeams { get; set; }

		[JsonProperty("waiver_type")]
		public string WaiverType { get; set; }

		[JsonProperty("waiver_rule")]
		public string WaiverRule { get; set; }

		[JsonProperty("uses_faab")]
		public string UsesFaab { get; set; }

		[JsonProperty("draft_time")]
		public string DraftTime { get; set; }

		[JsonProperty("draft_pick_time")]
		public string DraftPickTime { get; set; }

		[JsonProperty("post_draft_players")]
		public string PostDraftPlayers { get; set; }

		[JsonProperty("max_teams")]
		public string MaxTeams { get; set; }

		[JsonProperty("waiver_time")]
		public string WaiverTime { get; set; }

		[JsonProperty("trade_end_date")]
		public string TradeEndDate { get; set; }

		[JsonProperty("trade_ratify_type")]
		public string TradeRatifyType { get; set; }

		[JsonProperty("trade_reject_time")]
		public string TradeRejectTime { get; set; }

		[JsonProperty("player_pool")]
		public string PlayerPool { get; set; }

		[JsonProperty("cant_cut_list")]
		public string CantCutList { get; set; }

		[JsonProperty("roster_positions")]
		public RosterPositions[] RosterPositions { get; set; }

		[JsonProperty("stat_categories")]
		public StatCategories StatCategories { get; set; }

		[JsonProperty("stat_modifiers")]
		public StatModifiers StatModifiers { get; set; }

		[JsonProperty("divisions")]
		public Division[] Divisions { get; set; }

		[JsonProperty("pickem_enabled")]
		public string PickemEnabled { get; set; }

		[JsonProperty("uses_fractional_points")]
		public string UsesFractionalPoints { get; set; }

		[JsonProperty("uses_negative_points")]
		public string UsesNegativePoints { get; set; }

	}
	public class StatCategories
	{
		[JsonProperty("stats")]
		public Stat[] Stats { get; set; }

	}
	public class Stat
	{
		[JsonProperty("stat")]
		public Stat1 Stat { get; set; }

	}
	public class Stat1
	{
		[JsonProperty("stat_id")]
		public int StatId { get; set; }

		[JsonProperty("enabled")]
		public string Enabled { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("display_name")]
		public string DisplayName { get; set; }

		[JsonProperty("sort_order")]
		public string SortOrder { get; set; }

		[JsonProperty("position_type")]
		public string PositionType { get; set; }

		[JsonProperty("stat_position_types")]
		public StatPosition_Types[] StatPositionTypes { get; set; }

		[JsonProperty("is_only_display_stat")]
		public string IsOnlyDisplayStat { get; set; }

		[JsonProperty("is_excluded_from_display")]
		public string IsExcludedFromDisplay { get; set; }

	}
	public class StatPositionTypes
	{
		[JsonProperty("stat_position_type")]
		public StatPosition_Type StatPositionType { get; set; }

	}
	public class StatPositionType
	{
		[JsonProperty("position_type")]
		public string PositionType { get; set; }

		[JsonProperty("is_only_display_stat")]
		public string IsOnlyDisplayStat { get; set; }

	}
	public class StatModifiers
	{
		[JsonProperty("stats")]
		public Stat2[] Stats { get; set; }

	}
	public class Stat2
	{
		[JsonProperty("stat")]
		public Stat3 Stat { get; set; }

	}
	public class Stat3
	{
		[JsonProperty("stat_id")]
		public int StatId { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }

		[JsonProperty("bonuses")]
		public Bonus[] Bonuses { get; set; }

	}
	public class Bonus
	{
		[JsonProperty("bonus")]
		public Bonus1 Bonus { get; set; }

	}
	public class Bonus1
	{
		[JsonProperty("target")]
		public int Target { get; set; }

		[JsonProperty("points")]
		public string Points { get; set; }

	}
	public class RosterPositions
	{
		[JsonProperty("roster_position")]
		public RosterPosition RosterPosition { get; set; }

	}
	public class RosterPosition
	{
		[JsonProperty("position")]
		public string Position { get; set; }

		[JsonProperty("position_type")]
		public string PositionType { get; set; }

		[JsonProperty("count")]
		public int Count { get; set; }

	}
	public class Division
	{
		[JsonProperty("division")]
		public Division1 Division { get; set; }

	}
	public class Division1
	{
		[JsonProperty("division_id")]
		public int DivisionId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

	}


}
