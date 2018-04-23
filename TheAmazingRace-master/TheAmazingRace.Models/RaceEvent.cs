using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAmazingRace.Models
{
    public class RaceEvent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DisplayName("Event Name")]
        [Index(IsUnique = true)]
        public string EventName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Event Date")]
        public DateTime EventDate { get; set; }

        [Required]
        public string Address { get; set; }

        [StringLength(6, MinimumLength=6)]
        [RegularExpression(@"\d*")]
        public string PostalCode { get; set; }

        [Required]
        [Range(-90.000, 90.0000)]
        [Display(Name = "Start Latitude")]
        public double StartLatitude { get; set; }

        [Required]
        [Range(-180.000, 180.0000)]
        [Display(Name="Start Longitude")]
        public double StartLongitude { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name="Additional Information")]
        public string AdditionalInfo { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public string UpdatedById { get; set; }
        [ForeignKey("UpdatedById")]
        public virtual User UpdatedBy { get; set; }

        //public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<PitStop> PitStops { get; set; }
    }
}
