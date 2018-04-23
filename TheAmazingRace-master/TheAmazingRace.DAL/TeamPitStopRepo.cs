using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingRace.Models;

namespace TheAmazingRace.DAL
{
    public class TeamPitStopRepo : BaseRepo<TeamPitStop>
    {
        private TheAmazingRaceDbContext dbContext = DbContextFactory.Create();
    }
}
