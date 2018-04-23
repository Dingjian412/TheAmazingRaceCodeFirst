using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingRace.DAL;
using TheAmazingRace.Models;

namespace TheAmazingRace.BLL
{
    public class TeamPitStopService : BaseService<TeamPitStop>
    {
        private TeamPitStopRepo repo = new TeamPitStopRepo();

        public TeamPitStopService()
        {
            this.Repo = repo;
        }
    }
}
