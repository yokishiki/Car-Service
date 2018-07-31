using System.Collections.ObjectModel;
using System.Linq;

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

        public ObservableCollection<Car> GetCars()
        {
            return new ObservableCollection<Car>(BinContext.OrdersInfo.Cars);
        }

        public ObservableCollection<Owner> GetOwners()
        {
            return new ObservableCollection<Owner>(BinContext.OrdersInfo.Owners);
        }

        public void AddOrder(Order order)
        {
            BinContext.WriteOrderToBinaryFile(order);
        }

        public void AddOwner(Owner owner)
        {
            BinContext.WriteOwnerToBinaryFile(owner);
        }

        public void AddCar(Car car)
        {
            BinContext.WriteCarToBinaryFile(car);
        }

    }
}
