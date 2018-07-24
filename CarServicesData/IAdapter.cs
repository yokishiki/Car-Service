using System.Collections.ObjectModel;

namespace Car_Services
{
    public interface IAdapter
    {
        ObservableCollection<Order> GetOrders();
    }
}
