using System.Collections.Generic;
using System.Linq;

namespace Car_Services
{
    public class EFAdapter : IAdapter
    {
        private CarServiceDbContext db;

        public IEnumerable<Order> GetOrders()
        {
            db = new CarServiceDbContext();
            return db.Orders.ToList();
        }
    }
}
