using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAmazingRace.DAL;
using TheAmazingRace.Models;

namespace TheAmazingRace.Utilities
{
    public class AppRoleManager
    {
        public static RoleManager<IdentityRole> RoleManager()
        {
            TheAmazingRaceDbContext context = TheAmazingRaceDbContext.Create();
            return new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }
    }
}