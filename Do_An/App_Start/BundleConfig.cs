using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Do_An.App_Start
{
    public class BundleConfig
    {
        public static void BundleAdd(BundleCollection bundle)
        {
            //--Add style css to bundle for private pages
            bundle.Add(new StyleBundle("~/bundle/cssPV").Include("~/Content/all.min.css",
                                                                 "~/Content/adminlte.min.css",
                                                                 "~/Content/summernote-bs4.css",
                                                                 "~/Content/dataTable.bootstrap4.css"));
            //-Add scrip to the bundle for private pages
            bundle.Add(new ScriptBundle("~/bundle/scriptsPV").Include("~/Scripts/jquery.min.js",
                                                                      "~/Scripts/bootstrap.bundle.min.js",
                                                                      "~/Scripts/adminlte.min.js",
                                                                      "~/Scripts/demo.js",
                                                                      "~/Scripts/jquery.dataTable.js",
                                                                      "~/Scripts/dataTable.bootstrap4.js"));
        }
    }
}