using System.Collections.ObjectModel;
using System.ComponentModel;
using OrderInfo;

namespace Car_Services
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            _loadCommand = new Command(LoadData);
            InitSources();
        }

        private IAdapter adapter;
        private ObservableCollection<Order> _orders;
        private ObservableCollection<string> _sourceData; //list of inputs
        private string _selectedItem; //item which selected in comboBox

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void InitSources()
        {
            _sourceData = new ObservableCollection<string>();
            _sourceData.Add("Database");
            _sourceData.Add("XML");
            _sourceData.Add("Binary file");
        }

        private void LoadData()
        {
            if (SelectedItem == "Database")
                adapter = new EFAdapter();
            else if (SelectedItem == "XML")
                adapter = new XmlAdapter();
            else if (SelectedItem == "Binary file")
                adapter = new BinAdapter();
            if (adapter != null)
                LoadOrders();
        }

        private void LoadOrders()
        {
            Orders = null;
            Orders = new ObservableCollection<Order>(adapter.GetOrders());
           
        }
    }
}