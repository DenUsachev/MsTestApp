using System;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TestApp.Import.Interfaces;

namespace TestApp.Client.Models
{
    public class MainViewModel : ViewModelBase
    {
        private Microsoft.Win32.OpenFileDialog _openDialog;
        private readonly IFileUploader _fileUploader;

        public ICommand CloseAppCommand { get; set; }
        public ICommand ImportCommand { get; set; }
        public bool CanCloseAppFlag { get; set; }

        public MainViewModel(IFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
            CanCloseAppFlag = true;
            CloseAppCommand = new RelayCommand(CloseApp, CanCloseApp);
            ImportCommand = new RelayCommand(Import);
            _openDialog = new Microsoft.Win32.OpenFileDialog { Filter = "XML Files (*.xml)|*.xml" };
        }

        private void Import()
        {
            if (_openDialog.ShowDialog() == true)
            {
                try
                {
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
