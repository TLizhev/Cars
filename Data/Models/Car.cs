using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Cars.Data.DataConstants;
namespace Cars.Data.Models
{
    public class Car
    {
        public int Id { get; init; }
        [Required]
        [MaxLength(CarBrandMaxLength)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(CarModelMaxLength)]
        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public int Year { get; set; }
       
        public int CategoryId { get; set; }

        public Category Category { get; init; }

        public int DealerId { get; init; }

        public Dealer Dealer { get; init; }
    }
}
