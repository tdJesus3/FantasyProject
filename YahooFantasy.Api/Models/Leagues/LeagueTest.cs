using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Api.Models.Leagues
{

	public class Rootobject
	{
		public Fantasy_Content fantasy_content { get; set; }
	}

	public class Fantasy_Content
	{
		public string xmllang { get; set; }
		public string yahoouri { get; set; }
		public League[] league { get; set; }
		public string time { get; set; }
		public string copyright { get; set; }
		public string refresh_rate { get; set; }
	}

	public class League
	{
		public string league_key { get; set; }
		public string league_id { get; set; }
		public string name { get; set; }
		public string url { get; set; }
		public string draft_status { get; set; }
		public int num_teams { get; set; }
		public int edit_key { get; set; }
		public string weekly_deadline { get; set; }
		public string league_update_timestamp { get; set; }
		public string scoring_type { get; set; }
		public string league_type { get; set; }
		public string renew { get; set; }
		public string renewed { get; set; }
		public string short_invitation_url { get; set; }
		public string is_pro_league { get; set; }
		public int current_week { get; set; }
		public string start_week { get; set; }
		public string start_date { get; set; }
		public string end_week { get; set; }
		public string end_date { get; set; }
		public Setting[] settings { get; set; }
	}

	public class Setting
	{
		public string draft_type { get; set; }
		public string is_auction_draft { get; set; }
		public string scoring_type { get; set; }
		public string uses_playoff { get; set; }
		public bool has_playoff_consolation_games { get; set; }
		public string playoff_start_week { get; set; }
		public int uses_playoff_reseeding { get; set; }
		public int uses_lock_eliminated_teams { get; set; }
		public string num_playoff_teams { get; set; }
		public int num_playoff_consolation_teams { get; set; }
		public string waiver_type { get; set; }
		public string waiver_rule { get; set; }
		public string uses_faab { get; set; }
		public string draft_time { get; set; }
		public string draft_pick_time { get; set; }
		public string post_draft_players { get; set; }
		public string max_teams { get; set; }
		public string waiver_time { get; set; }
		public string trade_end_date { get; set; }
		public string trade_ratify_type { get; set; }
		public string trade_reject_time { get; set; }
		public string player_pool { get; set; }
		public string cant_cut_list { get; set; }
		public Roster_Positions[] roster_positions { get; set; }
		public Stat_Categories stat_categories { get; set; }
		public Stat_Modifiers stat_modifiers { get; set; }
		public Division[] divisions { get; set; }
		public string pickem_enabled { get; set; }
		public string uses_fractional_points { get; set; }
		public string uses_negative_points { get; set; }
	}

	public class Stat_Categories
	{
		public Stat[] stats { get; set; }
	}

	public class Stat
	{
		public Stat1 stat { get; set; }
	}

	public class Stat1
	{
		public int stat_id { get; set; }
		public string enabled { get; set; }
		public string name { get; set; }
		public string display_name { get; set; }
		public string sort_order { get; set; }
		public string position_type { get; set; }
		public Stat_Position_Types[] stat_position_types { get; set; }
		public string is_only_display_stat { get; set; }
		public string is_excluded_from_display { get; set; }
	}

	public class Stat_Position_Types
	{
		public Stat_Position_Type stat_position_type { get; set; }
	}

	public class Stat_Position_Type
	{
		public string position_type { get; set; }
		public string is_only_display_stat { get; set; }
	}

	public class Stat_Modifiers
	{
		public Stat2[] stats { get; set; }
	}

	public class Stat2
	{
		public Stat3 stat { get; set; }
	}

	public class Stat3
	{
		public int stat_id { get; set; }
		public string value { get; set; }
		public Bonus[] bonuses { get; set; }
	}

	public class Bonus
	{
		public Bonus1 bonus { get; set; }
	}

	public class Bonus1
	{
		public int target { get; set; }
		public string points { get; set; }
	}

	public class Roster_Positions
	{
		public Roster_Position roster_position { get; set; }
	}

	public class Roster_Position
	{
		public string position { get; set; }
		public string position_type { get; set; }
		public int count { get; set; }
	}

	public class Division
	{
		public Division1 division { get; set; }
	}

	public class Division1
	{
		public int division_id { get; set; }
		public string name { get; set; }
	}

}
