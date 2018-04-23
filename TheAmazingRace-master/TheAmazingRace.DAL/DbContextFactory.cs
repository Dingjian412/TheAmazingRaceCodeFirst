using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace TheAmazingRace.DAL
{
    public partial class DbContextFactory
    {
        public static TheAmazingRaceDbContext Create()
        {
            TheAmazingRaceDbContext dbContext = CallContext.GetData("DbContext") as TheAmazingRaceDbContext;
            if (dbContext == null)
            {
                dbContext = new TheAmazingRaceDbContext();
                CallContext.SetData("DbContext", dbContext);
            }

            return dbContext;
        }
    }
}
