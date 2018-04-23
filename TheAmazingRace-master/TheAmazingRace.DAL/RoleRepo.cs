using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingRace.Models;

namespace TheAmazingRace.DAL
{
    public class RoleRepo : BaseRepo<Role>
    {
        private TheAmazingRaceDbContext dbContext = DbContextFactory.Create();

        public Role GetById(string id)
        {
            try
            {
                return dbContext.Role.Where(r => r.Id == id).First();
            } catch (Exception)
            {
                throw;
            }
        }

        public Role GetByName(string name)
        {
            try
            {
                return dbContext.Role.Where(r => r.Name == name).First();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetRoleIdByName(string roleName)
        {
            try
            {
                return dbContext.Role.Where(r => r.Name == roleName).First().Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
