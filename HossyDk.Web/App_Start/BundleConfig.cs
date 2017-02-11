using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace HossyDk.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //styles
            bundles.Add(new StyleBundle("~/bundles/css/global").Include(
                "~/Content/Site.css",
                "~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/bundles/css/imageUpload").Include(
                        "~/Content/ImageUpload.css"));

            //scripts
            bundles.Add(new ScriptBundle("~/bundles/scripts/global").Include(
                "~/Scripts/modernizr-2.6.2.js",
                "~/Scripts/jquery-1.10.2.min.js",
                "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts/imageupload").Include(
                "~/Scripts/ImageUpload.js"));
        }
    }    
}