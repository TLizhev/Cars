
using Cars.Data;
using Cars.Data.Models;
using Cars.Models.Cars;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Cars.Controllers
{
    public class CarsController:Controller
    {

        private readonly CarsDbContext data;

        public CarsController(CarsDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add() => View(new AddCarFormModel
        {
            Categories = this.GetCarCategories()
        });

        [HttpPost]
        public IActionResult Add(AddCarFormModel car)
        {
           

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
            };
            this.data.Cars.Add(carData);
            this.data.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

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
