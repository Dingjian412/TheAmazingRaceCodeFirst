using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingRace.Models;

namespace TheAmazingRace.DAL
{
    public class RaceEventPitStopRepo : BaseRepo<RaceEventPitStop>
    {
        private TheAmazingRaceDbContext dbContext = DbContextFactory.Create();

        public RaceEventPitStop GetRaceEventPitStop(int raceEventId, int pitStopId)
        {
            try
            {
                return dbContext.RaceEventPitStop.Where(r => r.RaceEventId == raceEventId && r.PitStopId == pitStopId).First();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RaceEventPitStop> GetAllByRaceEventId(int raceId)
        {
            try
            {
                return dbContext.RaceEventPitStop.Where(r => r.RaceEventId == raceId).OrderBy(r => r.Order).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RaceEventPitStop GetRaceEventPitStopByPitId(int pitId)
        {
            try
            {
                return dbContext.RaceEventPitStop.Where(r => r.PitStopId == pitId).First();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
