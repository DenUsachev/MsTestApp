using System.Data.Entity;
using System.Windows;
using Ninject;
using TestApp.Domain;
using TestApp.Import;
using TestApp.Import.Interfaces;

namespace TestApp.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel _container;
        private const string APP_TITLE = "MS Test Task app";
        private const int APP_WINDOW_WIDTH = 800;
        private const int APP_WINDOW_HEIGHT = 500;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeInterface();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures an IoC container
        /// </summary>
        private void ConfigureContainer()
        {
            _container = new StandardKernel();
            _container.Bind<DbContext>().To<DataContext>().InTransientScope();
            _container.Bind<IFileUploader>().To<FileUploader>();
            _container.Bind<IDataRepository<CustomerEntry>>().To<DataRepository>().InTransientScope();
        }

        /// <summary>
        /// Initializes the UI
        /// </summary>
        private void ComposeInterface()
        {
            Current.MainWindow = _container.Get<MainWindow>();
            Current.MainWindow.Title = APP_TITLE;
            Current.MainWindow.Width = APP_WINDOW_WIDTH;
            Current.MainWindow.Height = APP_WINDOW_HEIGHT;
            Current.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
