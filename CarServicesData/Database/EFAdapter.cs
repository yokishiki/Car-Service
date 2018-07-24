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
    }
}
