using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Ninject;
using TestApp.Domain;
using TestApp.Import.Interfaces;

namespace TestApp.Client.Models
{
    public class MainViewModel : ViewModelBase
    {
        private readonly Microsoft.Win32.OpenFileDialog _openDialog;
        private IFileUploader _fileUploader;
        private readonly ObservableCollection<LogEntry> _logEntries;

        public ObservableCollection<LogEntry> LogEntries
        {
            get { return _logEntries; }
            set { RaisePropertyChanged(nameof(LogEntries), _logEntries, value, true); }
        }
        public ICommand CloseAppCommand { get; set; }
        public ICommand ImportCommand { get; set; }
        public ICommand ClearLogCommand { get; set; }
        public bool CanCloseAppFlag { get; set; }

        public MainViewModel()
        {
            CanCloseAppFlag = true;
            CloseAppCommand = new RelayCommand(CloseApp, CanCloseApp);
            ImportCommand = new RelayCommand(Import);
            ClearLogCommand = new RelayCommand(ClearLog, CanClearLog);
            _logEntries = new ObservableCollection<LogEntry>();
            _logEntries.Add(new LogEntry(DateTime.Now, "Application started"));
            _openDialog = new Microsoft.Win32.OpenFileDialog { Filter = "XML Files (*.xml)|*.xml|CSV Files (*.csv)|*.csv" };
        }

        /// <summary>
        /// Determines, whether the user can clear the log or not
        /// </summary>
        /// <returns></returns>
        private bool CanClearLog()
        {
            return _logEntries.Count > 0;
        }

        /// <summary>
        /// Clears operations log
        /// </summary>
        private void ClearLog()
        {
            _logEntries.Clear();
        }

        /// <summary>
        /// Performs the file import routine
        /// </summary>
        private void Import()
        {
            if (_openDialog.ShowDialog() == true)
            {
                try
                {
                    var resolveKey = Path.GetExtension(_openDialog.FileName).Substring(1);
                    _fileUploader = App.Container.Get<IFileUploader>(resolveKey);
                    _fileUploader.OnEventLogged += LogEvent;
                    _fileUploader.UploadFile(_openDialog.FileName);
                }
                catch (Exception ex)
                {
                    LogEntries.Add(new LogEntry(DateTime.Now, ex.Message));
                }
                finally
                {
                    _fileUploader.OnEventLogged -= LogEvent;
                    LogEvent(this, "File import complete.");
                }
            }
        }

        /// <summary>
        /// Logs an import event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventText">The text of the message</param>
        private void LogEvent(object sender, string eventText)
        {
            _logEntries.Add(new LogEntry(DateTime.Now, eventText));
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
