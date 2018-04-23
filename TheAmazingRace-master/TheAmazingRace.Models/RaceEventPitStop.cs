using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAmazingRace.Models
{
    public class RaceEventPitStop
    {
        [Key, Column(Order = 0)]
        public int RaceEventId { get; set; }
        [ForeignKey("RaceEventId")]
        public virtual RaceEvent RaceEvent { get; set; }

        [Key, Column(Order = 1)]
        public int PitStopId { get; set; }
        [ForeignKey("PitStopId")]
        public virtual PitStop PitStop { get; set; }

        public int Order { get; set; }
    }
}
