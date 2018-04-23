using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingRace.DAL;
using TheAmazingRace.Models;

namespace TheAmazingRace.BLL
{
    public class RaceEventUserService : BaseService<RaceEventUser>
    {
        private RaceEventUserRepo repo = new RaceEventUserRepo();
        private UserRepo userRepo = new UserRepo();

        public RaceEventUserService()
        {
            this.Repo = repo;
        }

        public RaceEventUser GetById(int raceEventId, string userId)
        {
            return repo.GetById(raceEventId, userId);
        }

        public bool AddStaffToRace(int raceEventId, string staffId)
        {
            var data = repo.Create();
            data.RaceEventId = raceEventId;
            data.UserId = staffId;

            repo.Add(data);

            return repo.SaveChanges();
        }

        public bool RemoveStaffFromRace(int raceEventId, string staffId)
        {
            var data = repo.GetById(raceEventId, staffId);
            repo.Delete(data);

            return repo.SaveChanges();
        }

        //updated by dj
        public bool UpdateStaffLocation(int raceEventId, string userEmail, double currLong, double currLat)
        {
            User user = userRepo.GetByEmail(userEmail);
            var data = repo.GetById(raceEventId, user.Id);
            data.CurrentLong = currLong;
            data.CurrentLat = currLat;
            repo.Update(data);

            return repo.SaveChanges();
        }

        public IEnumerable<User> GetAllStaffsByRaceEventId(int raceEventId)
        {
            return userRepo.GetAllByRaceEventId(raceEventId);
        }

        //dj
        public IEnumerable<RaceEventUser> GetEventStaffByRaceEventId(int raceEventId)
        {
            return repo.GetUsersByEventId(raceEventId);
        }
    }
}
