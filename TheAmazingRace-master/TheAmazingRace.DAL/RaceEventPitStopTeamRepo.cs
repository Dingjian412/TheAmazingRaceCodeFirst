using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingRace.Models;

namespace TheAmazingRace.DAL
{
    public class RaceEventPitStopTeamRepo : BaseRepo<RaceEventPitStopTeam>
    {
        private TheAmazingRaceDbContext dbContext = DbContextFactory.Create();

        public List<RaceEventPitStopTeam> GetLeaderboard(int raceEventId)
        {
            var query = string.Format(@"
WITH
TBL_A AS (
	SELECT 
		table_raw.RaceEventId,
		table_raw.TeamId,
		table_raw.PitStopId,
		table_raw.CompletedOn,
		table_raw.NoOfCompletedStop,
		RANK() OVER (PARTITION BY table_raw.RaceEventId, table_raw.TeamId ORDER BY table_raw.CompletedOn DESC) AS ranking 
	FROM dbo.RaceEventPitStopTeam AS table_raw),

TBL_B AS (
	SELECT 
		RaceEventId,
		TeamId,
		PitStopId,
		CompletedOn,
		NoOfCompletedStop
	FROM TBL_A
	WHERE ranking = 1),

TBL_C AS (
	SELECT 
		t.RaceEventId,
		t.Id AS TeamId,
		b.PitStopId,
		ISNULL(b.CompletedOn, '1970-01-01 00:00:00') as CompletedOn,
		b.NoOfCompletedStop
	FROM dbo.Team AS t
	LEFT JOIN TBL_B AS b ON t.RaceEventId = b.RaceEventId AND t.Id = b.TeamId)

SELECT
	RaceEventId,
	TeamId,
	PitStopId,
	CompletedOn,
	ISNULL(NoOfCompletedStop, 0) as NoOfCompletedStop
FROM TBL_C
WHERE RaceEventId = {0}
ORDER BY RaceEventId, NoOfCompletedStop DESC, CompletedOn
            ", raceEventId);

            try
            {
                return dbContext.RaceEventPitStopTeam.SqlQuery(query).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RaceEventPitStopTeam> GetRaceEventPitStopTeams(int raceEventId)
        {
            var query = string.Format(@"
SELECT 
	A.RaceEventId,
	B.Id as TeamId, 
	A.PitStopId,  
	C.CompletedOn,
	(A.[Order] + 1) as NoOfCompletedStop 
FROM dbo.RaceEventPitStop A
LEFT JOIN dbo.Team B ON A.RaceEventId = B.RaceEventId 
LEFT JOIN dbo.RaceEventPitStopTeam C ON B.Id = C.TeamId AND A.PitStopId = C.PitStopId 
WHERE A.RaceEventId = {0}
ORDER BY B.Id, A.[Order]
            ", raceEventId);

            try
            {
                return dbContext.RaceEventPitStopTeam.SqlQuery(query).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
