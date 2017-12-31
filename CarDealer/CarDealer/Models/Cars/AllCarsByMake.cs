namespace CarDealer.Models.Cars
{
    using System.Collections.Generic;
    using CarDealer.Services.Models;

    public class AllCarsByMake
    {
        public string Make { get; set; }
        public IEnumerable<CarModel> Cars { get; set; }
    }
}
