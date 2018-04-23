using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingRace.Models;

namespace TheAmazingRace.DAL
{
    public class TeamRepo : BaseRepo<Team>
    {
        private TheAmazingRaceDbContext dbContext = DbContextFactory.Create();

        public Team GetById(int teamId)
        {
            try
            {
                return dbContext.Team.Where(t => t.Id == teamId).First();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Team> GetAll(bool noRaceOnly)
        {
            try
            {
                if (noRaceOnly)
                {
                    return dbContext.Team.Where(t => t.RaceEventId == null).ToList();
                }
                else
                {
                    return dbContext.Team.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Team> GetAllByRaceEventId(int raceEventId)
        {
            try
            {
                return dbContext.Team.Where(t => t.RaceEventId == raceEventId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
