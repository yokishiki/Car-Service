using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Services
{
    public class AddOrderWindowViewModel : BaseViewModel
    {
        public AddOrderWindowViewModel(IAdapter adapter)
        {
            _adapter = adapter;
            _createOrderCmd = new Command(CreateOrder);
            Cars = _adapter.GetCars();
            NewOrder = new Order();
        }

        public Order NewOrder { get; set; }
        public ObservableCollection<Car> Cars { get; set; }

        private IAdapter _adapter;
        private Command _createOrderCmd;
        public Command CreateOrderCmd
        {
            get { return _createOrderCmd; }
        }
        public void CreateOrder()
        {
            _adapter.AddOrder(NewOrder);
            OnRequestClose();
        }
    }
}
