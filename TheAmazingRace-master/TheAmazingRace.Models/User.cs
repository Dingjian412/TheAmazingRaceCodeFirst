using Microsoft.AspNet.Identity.EntityFramework;
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
    public class User : IdentityUser
    {
        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of birth")]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        public byte[] PhotoData { get; set; }
        public string PhotoContentType { get; set; }

        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string PhotoSource
        {
            get
            {
                if (PhotoData != null)
                    return "data:" + PhotoContentType + ";base64," + Convert.ToBase64String(PhotoData, 0, PhotoData.Length);
                else
                    return null;
            }
        }

        [DisplayName("Created on")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }

        [DisplayName("Created by")]
        public virtual User CreatedBy { get; set; }

        [DisplayName("Updated on")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedById { get; set; }

        [DisplayName("Updated by")]
        public virtual User UpdatedBy { get; set; }

        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
