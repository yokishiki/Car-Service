using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderInfo;

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
