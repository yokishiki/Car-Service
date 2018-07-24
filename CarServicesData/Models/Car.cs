using System;

namespace Car_Services
{
    [Serializable]
    public class Car
    {
        public int CarId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public int Power { get; set; }

        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
