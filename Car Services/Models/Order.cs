using System;

namespace Car_Services
{
    [Serializable]
    public class Order
    {
        public int OrderId { get; set; }
        public string WorkName { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime? TimeFinish { get; set; }
        public int Price { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
