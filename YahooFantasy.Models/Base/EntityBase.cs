﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Models.Base
{
	public abstract class EntityBase
	{
		public int Id { get; set; }

		public DateTime CreatedAt { get; set; }

		public string CreatedBy { get; set; }

		public DateTime ModifiedAt { get; set; }

		public string ModifiedBy { get; set; }
	}
}