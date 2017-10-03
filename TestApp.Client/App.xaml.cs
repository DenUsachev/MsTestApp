using System.Data.Entity;
using System.Windows;
using Ninject;
using TestApp.Client.Models;
using TestApp.Domain;
using TestApp.Import;
using TestApp.Import.FileUploader;
using TestApp.Import.Interfaces;

namespace TestApp.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string APP_TITLE = "MS Test Task app";
        private const int APP_WINDOW_WIDTH = 800;
        private const int APP_WINDOW_HEIGHT = 500;

        public static IKernel Container { get; protected set; }

        /// <summary>
        /// Application startup
        /// </summary>
        /// <param name="e">Startup event agruments</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeInterface();
            Current.MainWindow.DataContext = Container.Get<MainViewModel>();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures an IoC container
        /// </summary>
        private void ConfigureContainer()
        {
            Container = new StandardKernel();
            Container.Bind<DbContext>().To<DataContext>().InTransientScope();
            Container.Bind<IDataRepository<CustomerEntry>>().To<CustomerRepository>().InTransientScope();
            Container.Bind<IFileUploader>().To<XmlFileUploader>().Named("xml");
            Container.Bind<IFileUploader>().To<CsvFileUploader>().Named("csv");
        }

        /// <summary>
        /// Initializes the UI
        /// </summary>
        private void ComposeInterface()
        {
            Current.MainWindow = Container.Get<MainWindow>();
            Current.MainWindow.Title = APP_TITLE;
            Current.MainWindow.Width = APP_WINDOW_WIDTH;
            Current.MainWindow.Height = APP_WINDOW_HEIGHT;
            Current.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
