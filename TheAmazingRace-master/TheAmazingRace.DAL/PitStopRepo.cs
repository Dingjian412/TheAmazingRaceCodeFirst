using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingRace.Models;

namespace TheAmazingRace.DAL
{
    public class PitStopRepo: BaseRepo<PitStop>
    {
        private TheAmazingRaceDbContext dbContext = DbContextFactory.Create();

        public PitStop GetById(int id)
        {
            try
            {
                return dbContext.PitStop.Where(p => p.Id == id).First();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
