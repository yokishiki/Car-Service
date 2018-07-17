using System.Collections.Generic;

namespace Car_Services
{
    interface IAdapter
    {
        IEnumerable<Order> GetOrders();
    }
}
