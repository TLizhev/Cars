using Cars.Data;
using Cars.Data.Models;
using static Cars.Data.Models.Dealer;
using Cars.Models.Cars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Cars.Data.Infrastructure;

namespace Cars.Controllers
{
    public class CarsController : Controller
    {

        private readonly CarsDbContext data;

        public CarsController(CarsDbContext data)
        {
            this.data = data;
        }
        [Authorize]
        public IActionResult Add()
        {
            return View(new AddCarFormModel
            {
                Categories = this.GetCarCategories()
            });
        }
        [HttpPost]
        [Authorize]
        public IActionResult Add(AddCarFormModel car)
        {
            var dealerId = this.data
                .Dealers
                .Where(d => d.UserId == this.User.GetId())
                .Select(d => d.Id)
                .FirstOrDefault();

            if (dealerId == 0)
            {

                return RedirectToAction(nameof(DealersController.Become));
            }

            if (!ModelState.IsValid)
            {
                car.Categories = this.GetCarCategories();
                return View(car);
            }
            var carData = new Car
            {
                Brand = car.Brand,
                Model = car.Model,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                CategoryId = car.CategoryId,
                Year = car.Year,
                DealerId = dealerId
            };
            this.data.Cars.Add(carData);
            this.data.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        private bool UserIsDealer()
        => this.data
            .Dealers
            .Any(d => d.UserId == this.User.GetId());
        public IEnumerable<CarCategoryViewModel> GetCarCategories()
        {
            return this.data
                 .Categories
                 .Select(c => new CarCategoryViewModel
                 {
                     Id = c.Id,
                     Name = c.Name,
                 })
             .ToList();
        }
    }
}
