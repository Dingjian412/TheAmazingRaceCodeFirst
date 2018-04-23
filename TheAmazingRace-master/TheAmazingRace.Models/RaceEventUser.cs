using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAmazingRace.Models
{
    public class RaceEventUser
    {
        [Key, Column(Order = 0)]
        public int RaceEventId { get; set; }
        [ForeignKey("RaceEventId")]
        public virtual RaceEvent RaceEvent { get; set; }

        [Key, Column(Order = 1)]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public double? CurrentLong { get; set; }
        public double? CurrentLat { get; set; }
    }
}
