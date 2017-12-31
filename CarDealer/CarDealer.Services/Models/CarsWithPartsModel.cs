namespace CarDealer.Services.Models
{
    using System.Collections.Generic;

  public class CarsWithPartsModel : CarModel
    {
        public IEnumerable<PartModel> Parts { get; set; }
    }
}
