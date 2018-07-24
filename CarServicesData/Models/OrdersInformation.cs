using System;
using System.Collections.Generic;

namespace Car_Services
{
    [Serializable]
    public class OrdersInformation
    {
        public List<Order> Orders { get; set; }
        public List<Car> Cars { get; set; }
        public List<Owner> Owners { get; set; }
    }
}
