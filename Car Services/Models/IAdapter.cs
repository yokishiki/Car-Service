using System.Collections.Generic;
using OrderInfo;

namespace Car_Services
{
    interface IAdapter
    {
        IEnumerable<Order> GetOrders();
    }
}
