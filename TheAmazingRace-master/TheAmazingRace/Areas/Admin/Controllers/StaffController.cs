using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheAmazingRace.Areas.Admin.Controllers
{
    public class StaffController : UserController
    {
        public StaffController()
        {
            base.RoleName = "Staff";
        }

        public override ActionResult Manage()
        {
            return base.Manage();
        }

        public override ActionResult Details(string id)
        {
            return base.Details(id);
        }

        public override ActionResult Create()
        {
            return base.Create();
        }

        public override ActionResult Edit(string id)
        {
            return base.Edit(id);
        }

        public override ActionResult Delete(string id)
        {
            return base.Delete(id);
        }
    }
}