namespace CarDealer.Services
{
    using CarDealer.Data;
    using System.Collections.Generic;
    using CarDealer.Services.Models;
    
    using System.Linq;

    public class CarService : ICarService
    {
        private readonly ApplicationDbContext db;

        public CarService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CarModel> GetCars(string make)
        {
            var cars = db.Cars
                .Where(c => c.Make.ToLower() == make)
                 .OrderBy(c => c.Model)
                 .ThenByDescending(c => c.TravelledDistance)
                 .Select(c => new CarModel
                 {
                     Model = c.Model,
                     Make = c.Make,
                     TravelledDistance = c.TravelledDistance
                 })
                 .ToList();


            return cars;
        }
        
        public IEnumerable<CarsWithPartsModel> WithParts()
        {
            var carsWithParts = db.Cars
                                 .Select(c => new CarsWithPartsModel
                                 {
                                     Make = c.Make,
                                     Model = c.Model,
                                     TravelledDistance = c.TravelledDistance,
                                     Parts = c.Parts.Select(p => new PartModel
                                                 {
                                                     Name = p.Part.Name,
                                                     Price = p.Part.Price
                                                 })


                                 })
                                 .ToList();

            return carsWithParts;
        }
    }
}
