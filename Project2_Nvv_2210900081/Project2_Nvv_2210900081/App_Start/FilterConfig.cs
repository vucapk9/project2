﻿using System.Web;
using System.Web.Mvc;

namespace Project2_Nvv_2210900081
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
