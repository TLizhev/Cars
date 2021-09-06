using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cars.Data.Models
{
    public class Dealer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        public IEnumerable<Car> Cars { get; set; } = new List<Car>();
    }
}
