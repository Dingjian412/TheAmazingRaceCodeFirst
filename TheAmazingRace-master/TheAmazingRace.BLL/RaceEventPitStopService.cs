using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingRace.DAL;
using TheAmazingRace.Models;

namespace TheAmazingRace.BLL
{
    public class RaceEventPitStopService : BaseService<RaceEventPitStop>
    {
        private RaceEventPitStopRepo repo = new RaceEventPitStopRepo();

        public RaceEventPitStopService()
        {
            this.Repo = repo;
        }

        public List<RaceEventPitStop> GetAllByRaceEventId(int raceEventId)
        {
            return repo.GetAllByRaceEventId(raceEventId);
        }

        public bool UpdatePitStopOrder(int raceEventId, List<int> pitStopIds)
        {
            List<RaceEventPitStop> oldData = this.GetAllByRaceEventId(raceEventId);
            int i = 0;
            foreach (var id in pitStopIds)
            {
                var e = repo.GetRaceEventPitStop(raceEventId, id);
                e.Order = i;
                repo.Update(e);
                i++;
            }

            return repo.SaveChanges();
        }

        public bool AddPitStop(int raceEventId, int pitStopId)
        {
            var data = this.GetAllByRaceEventId(raceEventId);
            var t = new RaceEventPitStop()
            {
                RaceEventId = raceEventId,
                PitStopId = pitStopId,
                Order = data.Count + 1
            };

            repo.Add(t);

            return repo.SaveChanges();
        }

        public bool RemovePitStop(int raceEventId, int pitStopId)
        {
            var data = repo.GetRaceEventPitStop(raceEventId, pitStopId);
            repo.Delete(data);
            return repo.SaveChanges();
        }
    }
}
