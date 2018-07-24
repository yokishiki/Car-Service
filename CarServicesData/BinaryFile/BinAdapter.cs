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

        public void AddOrder(Order order)
        {
            BinContext.OrdersInfo.Orders.Add(order);
            if (!BinContext.OrdersInfo.Cars.Contains(order.Car))
                BinContext.OrdersInfo.Cars.Add(order.Car);
            if (!BinContext.OrdersInfo.Owners.Contains(order.Car.Owner))
                BinContext.OrdersInfo.Owners.Add(order.Car.Owner);
            BinContext.WriteToBinaryFile();
        }
    }
}
