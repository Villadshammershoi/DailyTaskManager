using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DailyTaskMang.Controllers
{
    public class CategoryRouteController : Controller
    {
        // GET: CategoryRoute
        public ActionResult CreateCategory()
        {
            return View();
        }
    }
}