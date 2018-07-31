using System.Collections.ObjectModel;

namespace Car_Services
{
    public class BinAdapter : IAdapter
    {
        private BinContext bc;
        public BinAdapter()
        {
            bc = new BinContext();
        }

        public ObservableCollection<Order> GetOrders()
        {
            return new ObservableCollection<Order>(BinContext.OrdersInfo.Orders);
        }
    }
}
