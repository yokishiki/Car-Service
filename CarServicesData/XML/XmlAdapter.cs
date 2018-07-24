using System.Collections.ObjectModel;

namespace Car_Services
{
    public class XmlAdapter : IAdapter
    {
        public ObservableCollection<Order> GetOrders()
        {
            XmlContext xc = new XmlContext();
            return new ObservableCollection<Order>(xc.Orders);
        }
    }
}
