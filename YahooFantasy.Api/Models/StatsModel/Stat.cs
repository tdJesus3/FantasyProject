﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YahooFantasy.Api.Models.StatsModel
{
	public class Stat
	{
		[JsonProperty("stat")]
		public StatDetail StatDetail { get; set; }
	}
}