using System.Web;
using System.Web.Optimization;

namespace KrispyKreme
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {                    
            bundles.Add(new StyleBundle("~/Content/css").Include(                     
                      "~/Content/site/site.css",
                      "~/Content/plugins/normalize.css"));

            bundles.Add(new ScriptBundle("~/bundles/comunes").Include(
                      "~/Scripts/comunes/comun.js"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                      "~/Scripts/home/home.js"));
        }
    }
}
