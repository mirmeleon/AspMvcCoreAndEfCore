namespace CarDealer.Data.Models
{
    using System;
    using System.Collections.Generic;
    public  class Part
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double? Price { get; set; }

        public int Quantity { get; set; }

        public List<CarParts> Cars { get; set; } = new List<CarParts>();

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }
    }
}
