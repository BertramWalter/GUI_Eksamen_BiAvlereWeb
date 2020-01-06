using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_Eksamen_BiAvlereWeb.Models
{
    public class VarroaCount
    {
        public ApplicationUser AuthorOfData { get; set; }

        public string IdOfAuthor { get; set; }

        public long VarroaCountId { get; set; }
        [Required]
        [MaxLength(18)]
        [DisplayName("Bee hive")]
        public string BeeHive { get; set; }
        [Required]
        [DisplayName("Date")]
        public DateTime DateForCount { get; set; }
        [Required]
        [DisplayName("Number of days observed")]
        public int NumberOfDaysObserved { get; set; }
        //[Required]
        [DisplayName("Notation")]
        public string Comment { get; set; }

        [DisplayName("Postal code")]
        public string ZipCode { get; set; }
    }
}
