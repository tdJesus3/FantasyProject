﻿using System.Web;
using System.Web.Optimization;

namespace YahooFantasy.Web.Ui
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js",
						"~/Scripts/jquery.unobtrusive-ajax.*"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap-lumen.css",
					  "~/Content/site.css"));

			bundles.Add(new ScriptBundle("~/bundles/grid").Include(
				"~/Scripts/gridmvc.js",
				//"~/Scripts/gridmvc-ext.js",
				"~/Scripts/gridmvc.customwidgets.js"//,
				//"~/Scripts/ladda-bootstrap/ladda.min.js",
				//"~/Scripts/ladda-bootstrap/spin.min.js"));
				));

			bundles.Add(new StyleBundle("~/Content/grid").Include(
				"~/Content/ladda-bootstrap/ladda-themeless.min.css",
				"~/Content/Gridmvc.css"));

			// Set EnableOptimizations to false for debugging. For more information,
			// visit http://go.microsoft.com/fwlink/?LinkId=301862
			BundleTable.EnableOptimizations = true;
		}
	}
}
