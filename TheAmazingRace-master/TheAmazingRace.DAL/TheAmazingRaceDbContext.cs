using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Runtime.Remoting.Messaging;
using TheAmazingRace.Models;

namespace TheAmazingRace.DAL
{
    public partial class TheAmazingRaceDbContext : IdentityDbContext<User>
    {
        public TheAmazingRaceDbContext()
            : base("name=DefaultConnection")
        {

        }

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>().HasOptional(a => a.CreatedBy).WithMany().HasForeignKey(a => a.CreatedById);
            modelBuilder.Entity<User>().HasOptional(a => a.UpdatedBy).WithMany().HasForeignKey(a => a.UpdatedById);
        }

        public DbSet<RaceEvent> RaceEvent { get; set; }
        public DbSet<RaceEventPitStop> RaceEventPitStop { get; set; }
        public DbSet<RaceEventUser> RaceEventUser { get; set; }
        public DbSet<RaceEventPitStopTeam> RaceEventPitStopTeam { get; set; }

        public DbSet<PitStop> PitStop { get; set; }

        public DbSet<Team> Team { get; set; }
        public DbSet<TeamPitStop> TeamPitStop { get; set; }

        public DbSet<Role> Role { get; set; }
    }
}
