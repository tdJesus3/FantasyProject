
/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class root
{

	private rootAdp_info adp_infoField;

	private rootPlayer[] adp_dataField;

	/// <remarks/>
	public rootAdp_info adp_info
	{
		get
		{
			return this.adp_infoField;
		}
		set
		{
			this.adp_infoField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlArrayItemAttribute("player", IsNullable = false)]
	public rootPlayer[] adp_data
	{
		get
		{
			return this.adp_dataField;
		}
		set
		{
			this.adp_dataField = value;
		}
	}
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class rootAdp_info
{

	private byte teamsField;

	private byte roundsField;

	private ushort total_draftsField;

	private string start_dateField;

	private string end_dateField;

	/// <remarks/>
	public byte teams
	{
		get
		{
			return this.teamsField;
		}
		set
		{
			this.teamsField = value;
		}
	}

	/// <remarks/>
	public byte rounds
	{
		get
		{
			return this.roundsField;
		}
		set
		{
			this.roundsField = value;
		}
	}

	/// <remarks/>
	public ushort total_drafts
	{
		get
		{
			return this.total_draftsField;
		}
		set
		{
			this.total_draftsField = value;
		}
	}

	/// <remarks/>
	public string start_date
	{
		get
		{
			return this.start_dateField;
		}
		set
		{
			this.start_dateField = value;
		}
	}

	/// <remarks/>
	public string end_date
	{
		get
		{
			return this.end_dateField;
		}
		set
		{
			this.end_dateField = value;
		}
	}
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class rootPlayer
{

	private ushort idField;

	private decimal adpField;

	private decimal adp_overallField;

	private string nameField;

	private string posField;

	private string teamField;

	private ushort times_draftedField;

	private byte byeField;

	/// <remarks/>
	public ushort id
	{
		get
		{
			return this.idField;
		}
		set
		{
			this.idField = value;
		}
	}

	/// <remarks/>
	public decimal adp
	{
		get
		{
			return this.adpField;
		}
		set
		{
			this.adpField = value;
		}
	}

	/// <remarks/>
	public decimal adp_overall
	{
		get
		{
			return this.adp_overallField;
		}
		set
		{
			this.adp_overallField = value;
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
	public string pos
	{
		get
		{
			return this.posField;
		}
		set
		{
			this.posField = value;
		}
	}

	/// <remarks/>
	public string team
	{
		get
		{
			return this.teamField;
		}
		set
		{
			this.teamField = value;
		}
	}

	/// <remarks/>
	public ushort times_drafted
	{
		get
		{
			return this.times_draftedField;
		}
		set
		{
			this.times_draftedField = value;
		}
	}

	/// <remarks/>
	public byte bye
	{
		get
		{
			return this.byeField;
		}
		set
		{
			this.byeField = value;
		}
	}
}

