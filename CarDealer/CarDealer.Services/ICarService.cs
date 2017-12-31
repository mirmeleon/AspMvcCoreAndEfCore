namespace CarDealer.Services
{
    using System.Collections.Generic;
    using CarDealer.Services.Models;

    public interface ICarService
    {
        IEnumerable<CarModel> GetCars(string make);

        IEnumerable<CarsWithPartsModel> WithParts();
    }
}
