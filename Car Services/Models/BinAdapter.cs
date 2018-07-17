using System.Collections.Generic;

namespace Car_Services
{
    class BinAdapter : IAdapter
    {
        public IEnumerable<Order> GetOrders()
        {
            BinContext bc = new BinContext();
            return bc.OrdersInfo.Orders;
        }
    }
}
