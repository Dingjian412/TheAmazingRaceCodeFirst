using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingRace.Models;

namespace TheAmazingRace.DAL
{
    public class RaceEventUserRepo : BaseRepo<RaceEventUser>
    {
        private TheAmazingRaceDbContext dbContext = DbContextFactory.Create();

        public RaceEventUser GetById(int raceEventId, string userId)
        {
            try
            {
                return dbContext.RaceEventUser.Where(r => r.RaceEventId == raceEventId && r.UserId == userId).First();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RaceEventUser> GetUsersByEventId(int raceEventId)
        {
            try
            {
                return dbContext.RaceEventUser.Where(r => r.RaceEventId == raceEventId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
