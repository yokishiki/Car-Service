using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Car_Services
{

    public sealed class WindowService : IWindowService
    {
        private static readonly Lazy<WindowService> lazy =
            new Lazy<WindowService>(() => new WindowService());

        public static WindowService Instance { get { return lazy.Value; } }

        private WindowService() { }

        public void ShowWindow<T>(object dataContext) where T : Window, new()
        {
            var window = new T();
            ((BaseViewModel)dataContext).RequestClose += (s, e) => window.Close();
            window.DataContext = dataContext;
            window.Show();
        }
    }
}
