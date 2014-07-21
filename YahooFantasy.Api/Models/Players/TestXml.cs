using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Api.Models.Players
{

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng", IsNullable = false)]
	public partial class fantasy_content
	{

		private fantasy_contentGame gameField;

		private string langField;

		private string uriField;

		private string timeField;

		private string copyrightField;

		private byte refresh_rateField;

		/// <remarks/>
		public fantasy_contentGame game
		{
			get
			{
				return this.gameField;
			}
			set
			{
				this.gameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
		public string lang
		{
			get
			{
				return this.langField;
			}
			set
			{
				this.langField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.yahooapis.com/v1/base.rng")]
		public string uri
		{
			get
			{
				return this.uriField;
			}
			set
			{
				this.uriField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string time
		{
			get
			{
				return this.timeField;
			}
			set
			{
				this.timeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string copyright
		{
			get
			{
				return this.copyrightField;
			}
			set
			{
				this.copyrightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte refresh_rate
		{
			get
			{
				return this.refresh_rateField;
			}
			set
			{
				this.refresh_rateField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
	public partial class fantasy_contentGame
	{

		private ushort game_keyField;

		private ushort game_idField;

		private string nameField;

		private string codeField;

		private string typeField;

		private string urlField;

		private ushort seasonField;

		private fantasy_contentGamePlayers playersField;

		/// <remarks/>
		public ushort game_key
		{
			get
			{
				return this.game_keyField;
			}
			set
			{
				this.game_keyField = value;
			}
		}

		/// <remarks/>
		public ushort game_id
		{
			get
			{
				return this.game_idField;
			}
			set
			{
				this.game_idField = value;
			}
		}

		/// <remarks/>
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		public string code
		{
			get
			{
				return this.codeField;
			}
			set
			{
				this.codeField = value;
			}
		}

		/// <remarks/>
		public string type
		{
			get
			{
				return this.typeField;
			}
			set
			{
				this.typeField = value;
			}
		}

		/// <remarks/>
		public string url
		{
			get
			{
				return this.urlField;
			}
			set
			{
				this.urlField = value;
			}
		}

		/// <remarks/>
		public ushort season
		{
			get
			{
				return this.seasonField;
			}
			set
			{
				this.seasonField = value;
			}
		}

		/// <remarks/>
		public fantasy_contentGamePlayers players
		{
			get
			{
				return this.playersField;
			}
			set
			{
				this.playersField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
	public partial class fantasy_contentGamePlayers
	{

		private fantasy_contentGamePlayersPlayer[] playerField;

		private byte countField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("player")]
		public fantasy_contentGamePlayersPlayer[] player
		{
			get
			{
				return this.playerField;
			}
			set
			{
				this.playerField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
	public partial class fantasy_contentGamePlayersPlayer
	{

		private string player_keyField;

		private ushort player_idField;

		private fantasy_contentGamePlayersPlayerName nameField;

		private string statusField;

		private string editorial_player_keyField;

		private string editorial_team_keyField;

		private string editorial_team_full_nameField;

		private string editorial_team_abbrField;

		private fantasy_contentGamePlayersPlayerBye_weeks bye_weeksField;

		private byte uniform_numberField;

		private string display_positionField;

		private fantasy_contentGamePlayersPlayerHeadshot headshotField;

		private string image_urlField;

		private byte is_undroppableField;

		private string position_typeField;

		private fantasy_contentGamePlayersPlayerEligible_positions eligible_positionsField;

		private byte has_player_notesField;

		private bool has_player_notesFieldSpecified;

		/// <remarks/>
		public string player_key
		{
			get
			{
				return this.player_keyField;
			}
			set
			{
				this.player_keyField = value;
			}
		}

		/// <remarks/>
		public ushort player_id
		{
			get
			{
				return this.player_idField;
			}
			set
			{
				this.player_idField = value;
			}
		}

		/// <remarks/>
		public fantasy_contentGamePlayersPlayerName name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		public string status
		{
			get
			{
				return this.statusField;
			}
			set
			{
				this.statusField = value;
			}
		}

		/// <remarks/>
		public string editorial_player_key
		{
			get
			{
				return this.editorial_player_keyField;
			}
			set
			{
				this.editorial_player_keyField = value;
			}
		}

		/// <remarks/>
		public string editorial_team_key
		{
			get
			{
				return this.editorial_team_keyField;
			}
			set
			{
				this.editorial_team_keyField = value;
			}
		}

		/// <remarks/>
		public string editorial_team_full_name
		{
			get
			{
				return this.editorial_team_full_nameField;
			}
			set
			{
				this.editorial_team_full_nameField = value;
			}
		}

		/// <remarks/>
		public string editorial_team_abbr
		{
			get
			{
				return this.editorial_team_abbrField;
			}
			set
			{
				this.editorial_team_abbrField = value;
			}
		}

		/// <remarks/>
		public fantasy_contentGamePlayersPlayerBye_weeks bye_weeks
		{
			get
			{
				return this.bye_weeksField;
			}
			set
			{
				this.bye_weeksField = value;
			}
		}

		/// <remarks/>
		public byte uniform_number
		{
			get
			{
				return this.uniform_numberField;
			}
			set
			{
				this.uniform_numberField = value;
			}
		}

		/// <remarks/>
		public string display_position
		{
			get
			{
				return this.display_positionField;
			}
			set
			{
				this.display_positionField = value;
			}
		}

		/// <remarks/>
		public fantasy_contentGamePlayersPlayerHeadshot headshot
		{
			get
			{
				return this.headshotField;
			}
			set
			{
				this.headshotField = value;
			}
		}

		/// <remarks/>
		public string image_url
		{
			get
			{
				return this.image_urlField;
			}
			set
			{
				this.image_urlField = value;
			}
		}

		/// <remarks/>
		public byte is_undroppable
		{
			get
			{
				return this.is_undroppableField;
			}
			set
			{
				this.is_undroppableField = value;
			}
		}

		/// <remarks/>
		public string position_type
		{
			get
			{
				return this.position_typeField;
			}
			set
			{
				this.position_typeField = value;
			}
		}

		/// <remarks/>
		public fantasy_contentGamePlayersPlayerEligible_positions eligible_positions
		{
			get
			{
				return this.eligible_positionsField;
			}
			set
			{
				this.eligible_positionsField = value;
			}
		}

		/// <remarks/>
		public byte has_player_notes
		{
			get
			{
				return this.has_player_notesField;
			}
			set
			{
				this.has_player_notesField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool has_player_notesSpecified
		{
			get
			{
				return this.has_player_notesFieldSpecified;
			}
			set
			{
				this.has_player_notesFieldSpecified = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
	public partial class fantasy_contentGamePlayersPlayerName
	{

		private string fullField;

		private string firstField;

		private string lastField;

		private string ascii_firstField;

		private string ascii_lastField;

		/// <remarks/>
		public string full
		{
			get
			{
				return this.fullField;
			}
			set
			{
				this.fullField = value;
			}
		}

		/// <remarks/>
		public string first
		{
			get
			{
				return this.firstField;
			}
			set
			{
				this.firstField = value;
			}
		}

		/// <remarks/>
		public string last
		{
			get
			{
				return this.lastField;
			}
			set
			{
				this.lastField = value;
			}
		}

		/// <remarks/>
		public string ascii_first
		{
			get
			{
				return this.ascii_firstField;
			}
			set
			{
				this.ascii_firstField = value;
			}
		}

		/// <remarks/>
		public string ascii_last
		{
			get
			{
				return this.ascii_lastField;
			}
			set
			{
				this.ascii_lastField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
	public partial class fantasy_contentGamePlayersPlayerBye_weeks
	{

		private byte weekField;

		/// <remarks/>
		public byte week
		{
			get
			{
				return this.weekField;
			}
			set
			{
				this.weekField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
	public partial class fantasy_contentGamePlayersPlayerHeadshot
	{

		private string urlField;

		private string sizeField;

		/// <remarks/>
		public string url
		{
			get
			{
				return this.urlField;
			}
			set
			{
				this.urlField = value;
			}
		}

		/// <remarks/>
		public string size
		{
			get
			{
				return this.sizeField;
			}
			set
			{
				this.sizeField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
	public partial class fantasy_contentGamePlayersPlayerEligible_positions
	{

		private string positionField;

		/// <remarks/>
		public string position
		{
			get
			{
				return this.positionField;
			}
			set
			{
				this.positionField = value;
			}
		}
	}


}
