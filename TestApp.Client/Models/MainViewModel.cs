using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Ninject;
using TestApp.Import.Interfaces;

namespace TestApp.Client.Models
{
    public class MainViewModel : ViewModelBase
    {
        private readonly Microsoft.Win32.OpenFileDialog _openDialog;
        private IFileUploader _fileUploader;

        public ICommand CloseAppCommand { get; set; }
        public ICommand ImportCommand { get; set; }
        public bool CanCloseAppFlag { get; set; }

        public MainViewModel()
        {
            CanCloseAppFlag = true;
            CloseAppCommand = new RelayCommand(CloseApp, CanCloseApp);
            ImportCommand = new RelayCommand(Import);
            _openDialog = new Microsoft.Win32.OpenFileDialog { Filter = "XML Files (*.xml)|*.xml|CSV Files (*.csv)|*.csv" };
        }

        private void Import()
        {
            if (_openDialog.ShowDialog() == true)
            {
                try
                {
                    var resolveKey = Path.GetExtension(_openDialog.FileName).Substring(1);
                    _fileUploader = App.Container.Get<IFileUploader>(resolveKey);
                    _fileUploader.UploadFile(_openDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Import error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
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
