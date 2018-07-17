using System.Collections.Generic;
using OrderInfo;

namespace Car_Services
{
    class XmlAdapter : IAdapter
    {
        public IEnumerable<Order> GetOrders()
        {
            XmlContext xc = new XmlContext();
            return xc.Orders;
        }
    }
}
