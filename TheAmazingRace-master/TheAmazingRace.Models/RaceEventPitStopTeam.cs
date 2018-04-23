using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAmazingRace.Models
{
    public class RaceEventPitStopTeam
    {
        [Key, Column(Order = 0)]
        public int RaceEventId { get; set; }
        [ForeignKey("RaceEventId")]
        public virtual RaceEvent RaceEvent { get; set; }

        [Key, Column(Order = 1)]
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }

        [Key, Column(Order = 2)]
        public int NoOfCompletedStop { get; set; }

        public int? PitStopId { get; set; }
        [ForeignKey("PitStopId")]
        public virtual PitStop PitStop { get; set; }

        public DateTime? CompletedOn { get; set; }
    }
}
