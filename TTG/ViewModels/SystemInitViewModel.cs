using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TTG.Models;

namespace TTG.ViewModels
{
    public class SystemInitViewModel : ViewModelBase
    {
        private BackgroundWorker _initThread;
        readonly string checkOk = @"/Images/CheckOk.png";
        readonly string checkErr = @"/Images/CheckErr.png";
        public SystemInitViewModel()
        {
            InitIO = "I/O Board Initialing ...";
            InitMot = "Motion Board Initialing ...";
            InitCHR = "Sensor Initialing ...";
            InitCFG = "Configuration Initialing ...";
            InitTTG = "TTG App Initialing ...";

            StartUpIsEnabled = false;
            _mainSystem = new MainSystem();
            _mainSystem.Initialize();
            _initThread = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            _initThread.DoWork += Thread_DoWork;
            _initThread.ProgressChanged += Thread_ProgressChanged;
            _initThread.RunWorkerCompleted += Thread_RunWorkerCompleted;

            _initThread.RunWorkerAsync();
        }
        public event EventHandler OnRequestClose;
        private MainWindow _mainWindow;
        private MainWindowViewModel _mainWindowViewModel;
        private MainSystem _mainSystem;
        private static string _initIO;
        public string InitIO
        {
            get { return _initIO; }
            set
            {
                if (_initIO != value)
                {
                    _initIO = value;
                    OnChanged("InitIO");
                }
            }
        }
        private static string _initMot;
        public string InitMot
        {
            get { return _initMot; }
            set
            {
                if (_initMot != value)
                {
                    _initMot = value;
                    OnChanged("InitMot");
                }
            }
        }
        private static string _initCHR;
        public string InitCHR
        {
            get { return _initCHR; }
            set
            {
                if (_initCHR != value)
                {
                    _initCHR = value;
                    OnChanged("InitCHR");
                }
            }
        }
        private static string _initCFG;
        public string InitCFG
        {
            get { return _initCFG; }
            set
            {
                if (_initCFG != value)
                {
                    _initCFG = value;
                    OnChanged("InitCFG");
                }
            }
        }
        private static string _initTTG;
        public string InitTTG
        {
            get { return _initTTG; }
            set
            {
                if (_initTTG != value)
                {
                    _initTTG = value;
                    OnChanged("InitTTG");
                }
            }
        }
        private string _initIO_Check;
        public string InitIO_Check
        {
            get { return _initIO_Check; }
            set
            {
                if (_initIO_Check != value)
                {
                    _initIO_Check = value;
                    OnChanged("InitIO_Check");
                }
            }
        }
        private string _initIMot_Check;
        public string InitMot_Check
        {
            get { return _initIMot_Check; }
            set
            {
                if (_initIMot_Check != value)
                {
                    _initIMot_Check = value;
                    OnChanged("InitMot_Check");
                }
            }
        }
        private string _initCHR_Check;
        public string InitCHR_Check
        {
            get { return _initCHR_Check; }
            set
            {
                if (_initCHR_Check != value)
                {
                    _initCHR_Check = value;
                    OnChanged("InitCHR_Check");
                }
            }
        }
        private string _initCFG_Check;
        public string InitCFG_Check
        {
            get { return _initCFG_Check; }
            set
            {
                if (_initCFG_Check != value)
                {
                    _initCFG_Check = value;
                    OnChanged("InitCFG_Check");
                }
            }
        }
        private string _initTTG_Check;
        public string InitTTG_Check
        {
            get { return _initTTG_Check; }
            set
            {
                if (_initTTG_Check != value)
                {
                    _initTTG_Check = value;
                    OnChanged("InitTTG_Check");
                }
            }
        }
        private bool _startUpIsEnabled;
        public bool StartUpIsEnabled
        {
            get { return _startUpIsEnabled; }
            set
            {
                if (_startUpIsEnabled != value)
                {
                    _startUpIsEnabled = value;
                    OnChanged("StartUpIsEnabled");
                }
            }
        }
        private RelayCommand _startUpCommand;
        public RelayCommand StartUpCommand
        {
            get
            {
                if (_startUpCommand == null)
                    _startUpCommand = new RelayCommand(() => MainWindows_StartUp());
                return _startUpCommand;
            }
        }
        private void Thread_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!_mainSystem.SW_Simulation) //simul add
            {
                _mainSystem.HIO.Initialize();
                if (_mainSystem.HIO.IsInit)
                {
                    InitIO = "I/O Board Init. Completed ...";
                    Log.Write(LogLevel.Info, "[INIT]I/O Board Init. Completed.");
                    InitIO_Check = checkOk;
                }
                else
                {
                    InitIO = "I/O Board Init. Failed ...";
                    Log.Write(LogLevel.Error, "[INIT]I/O Board Init. Failed.");
                    InitIO_Check = checkErr;
                }

                _mainSystem.HMot.Initialize();
                if (_mainSystem.HMot.IsInit)
                {
                    InitMot = "Motion Board Init. Completed ...";
                    Log.Write(LogLevel.Info, "[INIT]Motion Board Init. Completed.");
                    InitMot_Check = checkOk;
                }
                else
                {
                    InitMot = "Motion Board Init. Failed ...";
                    Log.Write(LogLevel.Error, "[INIT]Motion Board Init. Failed.");
                    InitMot_Check = checkErr;
                }

                _mainSystem.HCHR.Initialize();
                if (_mainSystem.HCHR.IsInit)
                {
                    InitCHR = "Sensor Init.Completed ...";
                    Log.Write(LogLevel.Info, "[INIT]Sensor Init.Completed.");
                    InitCHR_Check = checkOk;
                }
                else
                {
                    InitCHR = "Sensor Init. Failed ...";
                    Log.Write(LogLevel.Error, "[INIT]Sensor Init. Failed.");
                    InitCHR_Check = checkErr;
                }

                if (true) //hr load추가
                {
                    InitCFG = "Configuration Init.Completed ...";
                    Log.Write(LogLevel.Info, "[INIT]Configuration Init.Completed.");
                    InitCFG_Check = checkOk;
                }
                else
                {
                    InitCFG = "Configuration Init. Failed ...";
                    Log.Write(LogLevel.Error, "[INIT]Configuration Init. Failed.");
                    InitCFG_Check = checkErr;
                }
            }
            else
            {
                InitIO = "I/O Board Init. Completed ...";
                InitMot = "Motion Board Init. Completed ...";
                InitCHR = "Sensor Init.Completed ...";
                InitCFG = "Configuration Init.Completed ...";
                InitIO_Check = checkOk;
                InitMot_Check = checkOk;
                InitCHR_Check = checkOk;
                InitCFG_Check = checkOk;
            }
        }

        private void Thread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        private void Thread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) 
        {
            if(e.Cancelled) 
            {
                InitTTG = "TTG App Init. Failed ...";
                Log.Write(LogLevel.Error, "[INIT]TTG App Init. Failed.");
                InitTTG_Check = checkErr;
            }
            else if(e.Error != null) 
            {
                InitTTG = "TTG App Init. Failed ...";
                Log.Write(LogLevel.Error, "[INIT]TTG App Init. Failed({0}).", e.Error.Message);
                InitTTG_Check = checkErr;
            }
            else
            {
                InitTTG = "TTG App Init.Completed...";
                Log.Write(LogLevel.Info, "[INIT]TTG Init. Completed.");
                InitTTG_Check = checkOk;
                StartUpIsEnabled = true;
            }
        }

        private void MainWindows_StartUp()
        {
            _mainWindowViewModel = new MainWindowViewModel(_mainSystem);
            _mainWindow = new MainWindow();
            _mainWindow.SetViewModel(_mainWindowViewModel);
            _mainWindow.Show();
           
            _initThread.Dispose();
            OnRequestClose(this, new EventArgs());
        }
    }
}
