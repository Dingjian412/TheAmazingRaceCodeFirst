using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAmazingRace.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int? RaceEventId { get; set; }

        public virtual RaceEvent Event { get; set; }

        public double CurrentLong { get; set; }
        public double CurrentLat { get; set; }

        [Display(Name = "Created On")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        public string CreatedById { get; set; }

        [Display(Name = "Created By")]
        public virtual User CreatedBy { get; set; }

        [Display(Name = "Updated On")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedOn { get; set; }

        public string UpdatedById { get; set; }

        [Display(Name = "Updated By")]
        public virtual User UpdatedBy { get; set; }

        [Display(Name = "Team Members")]
        [ForeignKey("TeamId")]
        public virtual ICollection<User> TeamMembers { get; set; }
    }
}
