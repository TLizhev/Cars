using Cars.Data;
using Cars.Data.Infrastructure;
using Cars.Data.Models;
using Cars.Models.Dealers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Cars.Controllers
{
    public class DealersController : Controller
    {

        private readonly CarsDbContext data;
        public DealersController(CarsDbContext data)
        {
            
            this.data = data;
        }
        [Authorize]
        public IActionResult Become() => View();
        [Authorize]
        [HttpPost]
        public IActionResult Become(BecomeDealerFormModel dealer)
        {
            var userId = this.User.GetId();
            var userIsAlreadyDealer = this.data.Dealers.Any(d => d.UserId ==userId);

            if (userIsAlreadyDealer)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(dealer);
            }
            var dealerData = new Dealer
            {
                Name = dealer.Name,
                PhoneNumber = dealer.PhoneNumber,
                UserId = userId,
            };
            this.data.Add(dealerData);
            this.data.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        
    }
}
