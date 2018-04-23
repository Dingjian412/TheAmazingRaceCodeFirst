using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheAmazingRace.Models
{
    public class TeamPitStop
    {
        [Key, Column(Order = 0)]
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }

        [Key, Column(Order = 1)]
        public int PitStopId { get; set; }
        [ForeignKey("PitStopId")]
        public virtual PitStop PitStop { get; set; }

        public bool Completed { get; set; }
        public DateTime CompletedOn { get; set; }
    }
}
