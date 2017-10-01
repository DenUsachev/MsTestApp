using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace TestApp.Client.Models
{
    internal class MainWindowContext : ViewModelBase
    {
        public ICommand CloseAppCommand { get; set; }
        public bool CanCloseAppFlag { get; set; }

        public MainWindowContext()
        {
            CanCloseAppFlag = true;
            CloseAppCommand = new RelayCommand(CloseApp, CanCloseApp);
        }

        /// <summary>
        /// Closes the App
        /// </summary>
        private static void CloseApp()
        {
            if (MessageBoxResult.Yes == MessageBox.Show("Do You want to close the application?", "Confirm exit", MessageBoxButton.YesNo, MessageBoxImage.Question))
                Application.Current.MainWindow.Close();
        }

        /// <summary>
        /// Determines, whether the user can close the App or not
        /// </summary>
        /// <returns></returns>
        private bool CanCloseApp()
        {
            return CanCloseAppFlag;
        }
    }
}
