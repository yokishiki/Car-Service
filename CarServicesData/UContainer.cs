using System.Collections.ObjectModel;
using System.Linq;
using Unity;

namespace Car_Services
{
    public class UContainer
    {
        private UnityContainer _container;

        public UContainer()
        {
            LoadContainer();
        }

        private void LoadContainer()
        {
            _container = new UnityContainer();
            _container.RegisterType<IAdapter, EFAdapter>("База данных");
            _container.RegisterType<IAdapter, XmlAdapter>("XML-файл");
            _container.RegisterType<IAdapter, BinAdapter>("Бинарный файл");
        }

        public ObservableCollection<string> GetSourses()
        {
            return new ObservableCollection<string>(_container.Registrations.Select(x => x.Name).ToList());
        }

        public IAdapter ChooseAdapter(string selectedItem)
        {
            return _container.Resolve<IAdapter>(selectedItem);
        }
    }
}
