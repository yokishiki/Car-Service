using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace Car_Services
{
    public class EFAdapter : IAdapter
    {
        public ObservableCollection<Order> GetOrders()
        {
            using (var db = new CarServiceDbContext())
            {
                return new ObservableCollection<Order>(db.Orders
                    .Include(x => x.Car)
                    .Include(x => x.Car.Owner)
                    .ToList());
            }
        }

        public ObservableCollection<Car> GetCars()
        {
            using (var db = new CarServiceDbContext())
            {
                return new ObservableCollection<Car>(db.Cars
                    .Include(x => x.Owner)
                    .ToList());
            }
        }

        public ObservableCollection<Owner> GetOwners()
        {
            using (var db = new CarServiceDbContext())
            {
                return new ObservableCollection<Owner>(db.Owners.ToList());
            }
        }

        public void AddOrder(Order order)
        {
            using (var db = new CarServiceDbContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public void AddCar(Car car)
        {
            using (var db = new CarServiceDbContext())
            {
                db.Cars.Add(car);
                db.SaveChanges();
            }
        }

        public void AddOwner(Owner owner)
        {
            using (var db = new CarServiceDbContext())
            {
                db.Owners.Add(owner);
                db.SaveChanges();
            }
        }
    }
}
