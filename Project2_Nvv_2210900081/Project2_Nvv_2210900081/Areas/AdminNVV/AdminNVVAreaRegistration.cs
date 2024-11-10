using System.Web.Mvc;

namespace Project2_Nvv_2210900081.Areas.AdminNVV
{
    public class AdminNVVAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminNVV";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminNVV_default",
                "AdminNVV/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}