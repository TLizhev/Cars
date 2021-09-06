
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Cars.Data.DataConstants;


namespace Cars.Models.Cars
{
    public class AddCarFormModel
    {
        [Required]
        [StringLength(CarBrandMaxLength,MinimumLength =CarBrandMinLength, ErrorMessage ="Must be between 2 and 30 characters")]
        public string Brand { get; init; }
        [Required]
        [StringLength(CarModelMaxLength, MinimumLength = CarModelMinLength, ErrorMessage = "Must be between 2 and 30 characters")]

        public string Model { get; init; }
       [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Must be between 10 and 100 characters")]

        public string Description { get; init; }
        [Required]
        [Url]
        [Display(Name ="Image URL")]
        public string ImageUrl { get; init; }
       [Required]
       [Range(2000,2050)]
        public int Year { get; init; }
        [Display(Name ="Category")]
        public int CategoryId { get; init; }

        public IEnumerable<CarCategoryViewModel> Categories { get; set; }
    }
}
