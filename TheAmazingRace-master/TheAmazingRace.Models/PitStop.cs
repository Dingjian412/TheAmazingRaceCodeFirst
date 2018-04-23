using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheAmazingRace.Models
{
    public class PitStop
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Display(Name="Pit Stop Name")]
        public string PitStopName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name="Challenge Description")]
        public string ChallengeDescription { get; set; }

        [Required]
        public string Address { get; set; }

        [StringLength(6, MinimumLength = 6)]
        [RegularExpression(@"\d*")]
        [Display(Name="Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [Range(-90.000, 90.0000)]
        public double Latitude { get; set; }

        [Required]
        [Range(-180.000, 180.0000)]
        public double Longitude { get; set; }

        [Display(Name="Created On")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        public string CreatedById { get; set; }

        [ForeignKey("CreatedById")]
        [Display(Name="Created By")]
        public virtual User CreatedBy { get; set; }

        [Display(Name = "Updated On")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedOn { get; set; }

        public string UpdatedById { get; set; }

        [ForeignKey("UpdatedById")]
        [Display(Name = "Updated By")]
        public virtual User UpdatedBy { get; set; }
    }
}
