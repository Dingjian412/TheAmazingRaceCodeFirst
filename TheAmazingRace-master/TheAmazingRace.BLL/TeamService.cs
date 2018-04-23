using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingRace.DAL;
using TheAmazingRace.Models;

namespace TheAmazingRace.BLL
{
    public class TeamService : BaseService<Team>
    {
        private TeamRepo repo = new TeamRepo();

        public TeamService()
        {
            this.Repo = repo;
        }

        public IEnumerable<Team> GetAllTeamsWithoutRace()
        {
            return repo.GetAll(true);
        }

        public Team GetById(int? teamId)
        {
            if(teamId != null)
            {
                return repo.GetById((int)teamId);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Team> GetAllByRaceEventId(int raceEventId)
        {
            return repo.GetAllByRaceEventId(raceEventId);
        }

        public bool AddTeamToRace(int raceEventId, int teamId, string updateById)
        {
            var team = GetById(teamId);
            team.RaceEventId = raceEventId;
            team.UpdatedOn = DateTime.Now;
            team.UpdatedById = updateById;

            repo.Update(team);

            return repo.SaveChanges();
        }

        public bool RemoveTeamFromRace(int raceEventId, int teamId, string updateById)
        {
            var team = GetById(teamId);
            team.RaceEventId = null;
            team.UpdatedOn = DateTime.Now;
            team.UpdatedById = updateById;

            repo.Update(team);

            return repo.SaveChanges();
        }

        public bool UpdateTeamLocation(int teamId, double currLong, double currLat)
        {
            var team = GetById(teamId);
            
            team.CurrentLong = currLong;
            team.CurrentLat = currLat;

            repo.Update(team);

            return repo.SaveChanges();
        }
    }
}
