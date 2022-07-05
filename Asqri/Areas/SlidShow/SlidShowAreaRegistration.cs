using System.Web.Mvc;

namespace Asqri.Areas.SlidShow
{
    public class SlidShowAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SlidShow";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SlidShow_default",
                "SlidShow/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}