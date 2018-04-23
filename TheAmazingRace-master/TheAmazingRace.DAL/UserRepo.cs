using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TheAmazingRace.Models;

namespace TheAmazingRace.DAL
{
    public class UserRepo : BaseRepo<User>
    {
        private TheAmazingRaceDbContext dbContext = DbContextFactory.Create();

        public User GetById(string id)
        {
            try
            {
                return dbContext.Users.Where(u => u.Id == id).First();
            } catch (Exception)
            {
                throw;
            }
        }

        //dj
        public User GetByEmail(string email)
        {
            try
            {
                return dbContext.Users.Where(u => u.Email == email).First();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAllExclude(string excludedUserId)
        {
            try
            {
                return dbContext.Users.Where(u => u.Id != excludedUserId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAllByRoleId(string roleId)
        {
            try
            {
                return dbContext.Users.Where(m => m.Roles.Select(r => r.RoleId).Contains(roleId)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAllExcludeByRoleId(string roleId, string excludedUserId)
        {
            try
            {
                return dbContext.Users.Where(m => m.Id != excludedUserId && m.Roles.Select(r => r.RoleId).Contains(roleId)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAllWithoutTeamByRoleId(string roleId)
        {
            try
            {
                return dbContext.Users.Where(m => m.TeamId == null && m.Roles.Select(r => r.RoleId).Contains(roleId)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAllByRaceEventId(int raceEventId)
        {
            try
            {
                return dbContext.RaceEventUser.Where(m => m.RaceEventId == raceEventId).Select(m => m.User).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
