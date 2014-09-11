using System.Web.Optimization;

namespace TheFantasyProject.Web.Charts
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
				"~/Scripts/jquery-{version}.js"));

			bundles.Add(new StyleBundle("~/Content/charts").Include(
				"~/Content/nv.d3.min.css"));

			bundles.Add(new ScriptBundle("~/bundles/charts").Include(
				"~/Scripts/d3.min.js",
				"~/Scripts/nv.d3.min.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
				"~/Content/site.css",
				"~/Content/toastr.min.css"));

			bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
				"~/Scripts/toastr.min.js"));

			bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
				"~/Content/bootstrap.min.css"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
				"~/Scripts/bootstrap.min.js"));

			// Set EnableOptimizations to false for debugging. For more information,
			// visit http://go.microsoft.com/fwlink/?LinkId=301862
			BundleTable.EnableOptimizations = true;
		}
	}
}