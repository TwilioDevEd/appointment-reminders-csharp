using System.Web;
using System.Web.Optimization;

namespace AppointmentReminders.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/lib/dist/js/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/lib/dist/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/datetime").Include(
                    "~/Scripts/lib/dist/js/moment.js",
                    "~/Scripts/lib/dist/js/bootstrap-datetimepicker.min.js",
                    "~/Scripts/common/datetimepicker-init.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Scripts/lib/dist/css/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/datetime").Include(
                    "~/Scripts/lib/dist/css/bootstrap-datetimepicker.css"));
        }
    }
}
