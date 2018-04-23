using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TheAmazingRace.DAL;
using TheAmazingRace.Models;

namespace TheAmazingRace.BLL
{
    public class UserService : BaseService<User>
    {
        private UserRepo repo = new UserRepo();
        private RoleRepo roleRepo = new RoleRepo();

        public UserService()
        {
            this.Repo = repo;
        }

        public User GetUserById(string userId)
        {
            return repo.GetById(userId);
        }

        //dj
        public User GetUserByEmail(string email)
        {
            return repo.GetByEmail(email);
        }

        public bool RemoveUserFromTeam(string userId)
        {
            User user = GetUserById(userId);
            user.TeamId = null;
            repo.Update(user);

            return repo.SaveChanges();
        }

        public IEnumerable<User> GetAllByRoleName(string role)
        {
            var roleId = roleRepo.GetRoleIdByName(role);
            return repo.GetAllByRoleId(roleId);
        }

        public IEnumerable<User> GetAllExcludeByRoleId(string role, string excludedUserId)
        {
            var roleId = roleRepo.GetRoleIdByName(role);
            return repo.GetAllExcludeByRoleId(roleId, excludedUserId);
        }

        public IEnumerable<User> GetAllParticipantsWithoutTeam()
        {
            var roleId = roleRepo.GetRoleIdByName("Participant");
            return repo.GetAllWithoutTeamByRoleId(roleId);
        }

        public IEnumerable<User> GetAllByRaceEventId(int raceEventId)
        {
            return repo.GetAllByRaceEventId(raceEventId);
        }
    }
}
