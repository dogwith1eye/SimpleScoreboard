﻿using System.Web;
using System.Web.Mvc;

namespace Doig.SimpleScoreboard
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
