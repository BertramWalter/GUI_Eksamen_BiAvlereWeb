using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GUI_Eksamen_BiAvlereWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public long ApplicationUserId { get; set; }

        [Required]
        [PersonalData]
        public string FirstName { get; set; }

        [Required]
        [PersonalData]
        public string LastName { get; set; }

        [Required]
        [PersonalData]
        [MaxLength(5)]
        public int DBF { get; set; }

        [Required]
        [PersonalData]
        public string Address1 { get; set; }

        [Required]
        [PersonalData]
        public string Address2 { get; set; }

        [Required]
        [PersonalData]
        public string ZipCode { get; set; }

        [Required]
        [PersonalData]
        public string Town { get; set; }
    }
}
