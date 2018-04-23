using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAmazingRace.DAL
{
    class DBInitializer : CreateDatabaseIfNotExists<TheAmazingRaceDbContext>
    {
        protected override void Seed(TheAmazingRaceDbContext context)
        {
            base.Seed(context);
        }
    }
}
