using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheAmazingRace.BLL;
using TheAmazingRace.Controllers;
using TheAmazingRace.DAL;
using TheAmazingRace.Models;

namespace TheAmazingRace.Areas.Admin.Controllers
{
    public class TeamController : Controller
    {
        TeamService TeamService = new TeamService();
        UserService UserService = new UserService();
        RoleService RoleService = new RoleService();

        // GET: Admin/Team/Manage
        public ActionResult Manage()
        {
            var models = TeamService.GetAll();
            return View(models);
        }

        // GET: Admin/Team/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Team/Create
        [HttpPost]
        public ActionResult Create(Team team)
        {
            try
            {
                team.CreatedOn = DateTime.Now;
                team.CreatedById = User.Identity.GetUserId();

                TeamService.Add(team);

                TempData["MessageAlert"] = new Alert { CssClass = "alert-success", Title = "Success!", Message = "Team is successfully created." };
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        public virtual ActionResult ManageTeam(int? id)
        {
            if (id > 0)
            {
                var team = TeamService.GetById(id);
                TempData["TeamId"] = id;
                return View(team);
            }
            else
            {
                return RedirectToAction("Manage", "Team");
            }
        }

        public virtual ActionResult Edit(int? id)
        {
            if (id > 0)
            {
                var pit = TeamService.GetById(id);
                return View(pit);
            }
            else
            {
                return RedirectToAction("Manage", "PitStop");
            }
        }

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            try
            {
                team.UpdatedOn = DateTime.Now;
                team.UpdatedById = User.Identity.GetUserId();

                TeamService.Update(team);
                TempData["MessageAlert"] = new Alert { CssClass = "alert-success", Title = "Success!", Message = "Team is successfully updated." };
                return RedirectToAction("Edit", new { id = team.Id });
            }
            catch
            {
                return View(team);
            }
        }

        public ActionResult _ParticipantList()
        {
            var currentUserId = User.Identity.GetUserId();
            var models = UserService.GetAllParticipantsWithoutTeam();

            return PartialView("_ParticipantList", models);
        }

        public ActionResult AddToTeam(string id)
        {
            var teamId = (int)TempData["TeamId"];
            var user = UserService.GetUserById(id);
            user.TeamId = teamId;

            UserService.Update(user);

            return RedirectToAction("ManageTeam", "Team", new { id = teamId });
        }

        public ActionResult RemoveUserFromTeam(string userId)
        {
            var teamId = (int)TempData["TeamId"];
            var user = UserService.RemoveUserFromTeam(userId);

            return RedirectToAction("ManageTeam", "Team", new { id = teamId });
        }
    }
}