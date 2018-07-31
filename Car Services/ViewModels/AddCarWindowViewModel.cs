using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Services
{
    public class AddCarWindowViewModel : BaseViewModel
    {
        public AddCarWindowViewModel(IAdapter adapter)
        {
            _adapter = adapter;
            _createCarCmd = new Command(CreateCar);
            Owners = _adapter.GetOwners();
            NewCar = new Car();
        }

        public Car NewCar { get; set; }
        public ObservableCollection<Owner> Owners { get; }

        private IAdapter _adapter;
        private Command _createCarCmd;
        public Command CreateCarCmd
        {
            get { return _createCarCmd; }
        }
        public void CreateCar()
        {
            _adapter.AddCar(NewCar);
            OnRequestClose();
        }
    }
}
