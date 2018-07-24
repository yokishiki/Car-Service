using System.Collections.ObjectModel;

namespace Car_Services
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            _loadCommand = new Command(LoadData);
            _container = new UContainer();
            InitSources();
        }

        private IAdapter adapter;
        private ObservableCollection<Order> _orders;
        private ObservableCollection<string> _sourceData; //list of inputs
        private string _selectedItem; //item which selected in comboBox
        private UContainer _container;

        private Command _loadCommand;
        public Command LoadCommand
        {
            get { return _loadCommand; }
        } 

        public ObservableCollection<Order> Orders
        {
            get
            {
                return _orders;
            }

            set
            {
                _orders = value;
                OnPropertyChanged("Orders");
            }
        }
        public ObservableCollection<string> SourceData
        {
            get
            {
                return _sourceData;
            }
        }
        public string SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private void InitSources()
        {
            _sourceData = _container.GetSourses();
        }


        private void LoadData()
        {
            if (SelectedItem != null)
                adapter = _container.ChooseAdapter(SelectedItem);
            if (adapter != null)
                LoadOrders();
        }

        private void LoadOrders()
        {
            Orders = null;
            Orders = adapter.GetOrders();           
        }
    }
}