using System.Collections.ObjectModel;

namespace Car_Services
{
    public interface IAdapter
    {
        ObservableCollection<Order> GetOrders();
        ObservableCollection<Car> GetCars();
        ObservableCollection<Owner> GetOwners();
        void AddOrder(Order order);
        void AddCar(Car car);
        void AddOwner(Owner owner);
    }
}
