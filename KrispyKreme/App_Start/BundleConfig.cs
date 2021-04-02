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

            bundles.Add(new StyleBundle("~/Content/plantilla").Include(
                      "~/Content/plugins/plantilla/style.css",
                      "~/Content/plugins/plantilla/bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/plantilla").Include(
                     "~/Scripts/plugins/plantilla/jquery.js",
                     "~/Scripts/plugins/plantilla/anime.js",
                      "~/Scripts/plugins/plantilla/bootstrap.min.js",
                      "~/Scripts/plugins/jquery-validation/dist/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/comunes").Include(
                      "~/Scripts/plugins/moment/moment.js",
                      "~/Scripts/comunes/comun.js"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                      "~/Scripts/home/home.js"));

            bundles.Add(new ScriptBundle("~/bundles/cupon").Include(
                      "~/Scripts/administrar/cupones.js"));
            
        }
    }
}
