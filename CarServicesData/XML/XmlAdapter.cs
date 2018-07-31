using System;
using System.Collections.ObjectModel;

namespace Car_Services
{
    public class XmlAdapter : IAdapter
    {
        XmlContext xc;

        public ObservableCollection<Order> GetOrders()
        {
            xc = new XmlContext();
            return new ObservableCollection<Order>(xc.Orders);
        }

        public ObservableCollection<Car> GetCars()
        {
            xc = new XmlContext();
            return new ObservableCollection<Car>(xc.Cars);
        }

        public ObservableCollection<Owner> GetOwners()
        {
            xc = new XmlContext();
            return new ObservableCollection<Owner>(xc.Owners);
        }

        public void AddCar(Car car)
        {
            xc.WriteCarToXmlFile(car);
        }

        public void AddOrder(Order order)
        {
            xc.WriteOrderToXmlFile(order);
        }

        public void AddOwner(Owner owner)
        {
            xc.WriteOwnerToXmlFile(owner);
        }
    }
}
