using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Models.Dealers
{
    public class BecomeDealerFormModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
