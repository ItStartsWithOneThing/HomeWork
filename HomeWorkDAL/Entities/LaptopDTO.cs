using System;

namespace HomeWorkDAL.Entities
{
    public class LaptopDTO
    {
        public Guid Id { get; set; }

        public string Model { get; set; }

        public int Ram { get; set; }

        public int Ssd { get; set; }

        public decimal Price { get; set; }

        public double Display { get; set; }

        public string Description { get; set; }
    }
}
