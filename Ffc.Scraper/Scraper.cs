using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using YahooFantasy.Models.Simple;

namespace Ffc.Scraper
{
    public static class Scraper
    {
		public static List<Adp> ScrapeDraft(int year)
		{
			var web = new HtmlWeb();
			var doc = web.Load("http://fantasyfootballcalculator.com/adp.php?format=standard&year=" + year.ToString() + "&teams=12&view=graph&pos=all");

			var rows = doc.DocumentNode.SelectSingleNode("//table[@class='adp']").SelectNodes(".//tr");

			var query = from row in rows
						where row.HasAttributes
						select row.SelectNodes(".//td")
							into fields
							select new Adp
							{
								PlayerName = HtmlEntity.DeEntitize(fields[2].InnerText),
								OverallAdp = Decimal.Parse(HtmlEntity.DeEntitize(fields[5].InnerText)),
								Year = year,
								TimesDrafted = Int32.Parse(HtmlEntity.DeEntitize(fields[9].InnerText)),
								Position = HtmlEntity.DeEntitize(fields[3].InnerText),
								Team = HtmlEntity.DeEntitize(fields[4].InnerText)
							};

			return query.ToList();
		}
    }
}
