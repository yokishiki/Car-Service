using System.Windows;

namespace Car_Services
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {            
                MainWindow mainView = new MainWindow();
                mainView.DataContext = new MainWindowViewModel();
                mainView.Show();   
        }
    }
}
