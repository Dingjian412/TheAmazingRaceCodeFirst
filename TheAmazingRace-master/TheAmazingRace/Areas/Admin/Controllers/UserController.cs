using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TheAmazingRace.Areas.Admin.Models;
using TheAmazingRace.BLL;
using TheAmazingRace.Controllers;
using TheAmazingRace.DAL;
using TheAmazingRace.Models;
using TheAmazingRace.Utilities;

namespace TheAmazingRace.Areas.Admin.Controllers
{
    [Authorize]
    public partial class UserController : AccountPartialController
    {
        private TheAmazingRaceDbContext context = TheAmazingRaceDbContext.Create();
        private UserService UserService = new UserService();

        public string RoleName { get; set; }

        public virtual ActionResult Manage()
        {
            var currentUserId = User.Identity.GetUserId();
            if (RoleName != "")
            {
                var models = UserService.GetAllByRoleName(RoleName);
                return View(models);
            }
            return View();
        }

        public virtual ActionResult Details(string id)
        {
            if (id != null)
            {
                var user = UserService.GetUserById(id);
                ViewData["GenderOptions"] = GenderOptions;
                return View(user);
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }

        public virtual ActionResult Create()
        {
            ViewData["GenderOptions"] = GenderOptions;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files[0];
                int contentLength = file.ContentLength;
                byte[] bytePhoto = new byte[contentLength];
                file.InputStream.Read(bytePhoto, 0, contentLength);

                model.AppUser.UserName = model.Email;
                model.AppUser.Email = model.Email;
                model.AppUser.PhotoData = bytePhoto;
                model.AppUser.PhotoContentType = file.ContentType;
                model.AppUser.CreatedById = User.Identity.GetUserId();
                model.AppUser.CreatedOn = DateTime.Now;

                var result = await base.UserManager.CreateAsync(model.AppUser, model.Password);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(model.AppUser.Id, RoleName);
                    TempData["MessageAlert"] = new Alert { CssClass = "alert-success", Title = "Success!", Message = RoleName + " is successfully created." };
                    return RedirectToAction("Create");
                }
                AddErrors(result);
            }

            ViewData["GenderOptions"] = GenderOptions;
            return View(model);
        }

        public virtual ActionResult Edit(string id)
        {
            if (id != null)
            {
                var appUser = UserService.GetUserById(id);
                ViewData["GenderOptions"] = GenderOptions;

                return View(appUser);
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                var newUser = UserService.GetUserById(user.Id);

                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.DOB = user.DOB;
                newUser.Gender = user.Gender;
                newUser.UpdatedOn = DateTime.Now;
                newUser.UpdatedById = User.Identity.GetUserId();

                UserService.Update(newUser);
                TempData["MessageAlert"] = new Alert { CssClass = "alert-success", Title = "Success!", Message = RoleName + " is successfully updated." };
                return RedirectToAction("Edit", new { id = user.Id });
            }
            catch
            {
                ViewData["GenderOptions"] = GenderOptions;
                return View(user);
            }
        }

        public virtual ActionResult Delete(string id)
        {
            if (id != null)
            {
                // TODO
                var user = UserService.GetUserById(id);
                ViewData["GenderOptions"] = GenderOptions;
                return View(user);
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }

        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO
                var user = UserService.GetUserById(id);
                UserService.Delete(user);
                //var deletedUser = UserService.getUserByAppUserId(appUser.User.Id);
                //UserService.Delete(deletedUser);

                return RedirectToAction("Manage");
            }
            catch
            {
                return RedirectToAction("Manage");
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public IEnumerable<SelectListItem> GenderOptions
        {
            get
            {
                List<SelectListItem> ddl = new List<SelectListItem>();
                ddl.Add(new SelectListItem { Text = "Male", Value = "Male" });
                ddl.Add(new SelectListItem { Text = "Female", Value = "Female" });
                return ddl;
            }
        }
    }
}