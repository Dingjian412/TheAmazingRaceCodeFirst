using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheAmazingRace.BLL;
using TheAmazingRace.Controllers;
using TheAmazingRace.Models;

namespace TheAmazingRace.Areas.Admin.Controllers
{
    public class PitStopController : Controller
    {
        private PitStopService pitStopService = new PitStopService();

        // GET: Admin/PitStop
        public ActionResult Manage()
        {
            var models = pitStopService.GetAll();
            return View(models);
        }

        // GET: Admin/PitStop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PitStop/Create
        [HttpPost]
        public ActionResult Create(PitStop pit)
        {
            try
            {
                pit.CreatedOn = DateTime.Now;
                pit.CreatedById = User.Identity.GetUserId();

                pitStopService.Add(pit);

                TempData["MessageAlert"] = new Alert { CssClass = "alert-success", Title = "Success!", Message = "Race event is successfully created." };
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        public virtual ActionResult Edit(int? id)
        {
            if (id > 0)
            {
                var pit = pitStopService.GetById(id);
                return View(pit);
            }
            else
            {
                return RedirectToAction("Manage", "PitStop");
            }
        }

        [HttpPost]
        public ActionResult Edit(PitStop pit)
        {
            try
            {
                pit.UpdatedOn = DateTime.Now;
                pit.UpdatedById = User.Identity.GetUserId();

                pitStopService.Update(pit);
                TempData["MessageAlert"] = new Alert { CssClass = "alert-success", Title = "Success!", Message = "Pit Stop is successfully updated." };
                return RedirectToAction("Edit", new { id = pit.Id });
            }
            catch
            {
                return View(pit);
            }
        }
    }
}