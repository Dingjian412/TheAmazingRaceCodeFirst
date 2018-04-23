using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using TheAmazingRace.DAL;
using TheAmazingRace.Models;

[assembly: OwinStartupAttribute(typeof(TheAmazingRace.Startup))]
namespace TheAmazingRace
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesAndUsers();
        }

        // In this method we will create default User roles and Admin user for login
        public void createRolesAndUsers()
        {
            var context = TheAmazingRaceDbContext.Create();
            var roleManager = new RoleManager<Role>(new RoleStore<Role>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User
            if (!roleManager.RoleExists("Administrator"))
            {
                var roles = new List<Role>
                 {
                    new Role{ Name = "Administrator" },
                    new Role{ Name = "Staff" },
                    new Role{ Name = "Participant" }
                 };

                roles.ForEach(r => roleManager.Create(r));

                ////Here we create a Admin super user who will maintain the website
                var admin = new User
                {
                    UserName = "admin@nus.edu",
                    Email = "admin@nus.edu",
                        FirstName = "Super",
                        LastName = "Admin",
                        DOB = DateTime.Now,
                        Gender = "Male",
                        CreatedBy = null,
                        CreatedOn = DateTime.Now
                };

                var result = userManager.Create(admin, "12345678");
                if (result.Succeeded)
                {
                    userManager.AddToRole(admin.Id, "Administrator");
                }
            }
        }
    }
}
