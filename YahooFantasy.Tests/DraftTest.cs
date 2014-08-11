using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ffc.Scraper;
using YahooFantasy.Data;

namespace YahooFantasy.Tests
{
	[TestClass]
	public class DraftTest
	{
		[TestMethod]
		public void TestScrapeDraft()
		{
			var draftData = Scraper.ScrapeDraft(2014);

			using (var context = new FantasyContext())
			{
				draftData.ForEach(d => context.Drafts.Add(d));
				context.SaveChanges();
			}
		}
	}
}
