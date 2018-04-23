using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheAmazingRace.BLL;

namespace TheAmazingRace.Areas.Admin.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _HeaderNavBar()
        {
            return PartialView("_HeaderNavBar");
        }

        public ActionResult _SideNavBar()
        {
            return PartialView("_SideNavBar");
        }
    }
}