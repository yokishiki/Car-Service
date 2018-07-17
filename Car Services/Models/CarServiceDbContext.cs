using System.Data.Entity;
using MySql.Data.Entity;
using OrderInfo;

namespace Car_Services
{
    // Code-Based Configuration and Dependency resolution  
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class CarServiceDbContext : DbContext
    {  
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }

        public CarServiceDbContext() : base("CarService") { }
    }
}
