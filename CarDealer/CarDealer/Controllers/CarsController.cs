namespace CarDealer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using CarDealer.Services;
    using CarDealer.Models.Cars;

    [Route("cars")]
    public class CarsController : Controller
    {
        private readonly ICarService cars;

        public CarsController(ICarService cars)
        {
            this.cars = cars;
        }

        [Route("{make}")]
        public IActionResult Index(string make)
        {
            var cars = this.cars.GetCars(make);

            var result = new AllCarsByMake
            {
                Cars = cars,
                Make = make
            };

            return View(result);
        }

        [Route("parts")]
        public IActionResult Parts()
        {
            return View(this.cars.WithParts());
        }
    }
}