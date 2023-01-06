using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TTG.Models;
using TTG.ViewModels.MainView;
using TTG.Views;
using TTG.Views.MainView;

namespace TTG.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Dispatcher _dispatcher;

        private MainSystem _mainSystem;
        public MainSystem MainSystem
        {
            get { return _mainSystem; }
            set { if (_mainSystem != value) { _mainSystem = value; OnChanged(""); } }
        }
        private MainOpViewModel _mainOpViewModel;
        private MainOpView _mainOpView;
        public System.Windows.Controls.UserControl MainOpView
        {
            get
            {
                return _mainOpView;
            }
        }
        private object _contentOpViewModel;
        public object ContentOpViewModel
        {
            get { return _contentOpViewModel; }
            private set { if (_contentOpViewModel != value) { _contentOpViewModel = value; OnChanged(""); } }
        }
        private MainSectionViewModel _mainSectionViewModel;
        private MainLogViewModel _mainLogViewModel;
        private object _contentSectionViewModel;
        public object ContentSectionViewModel
        {
            get { return _contentSectionViewModel; }
            private set { if (_contentSectionViewModel != value) { _contentSectionViewModel = value; OnChanged(""); } }
        }
        private object _contentLogViewModel;
        public object ContentLogViewModel
        {
            get { return _contentLogViewModel; }
            private set { if (_contentLogViewModel != value) { _contentLogViewModel = value; OnChanged(""); } }
        }

        private ChartViewModel _chartViewModel;
        private ChartView _chartView;
        public System.Windows.Controls.UserControl ChartView
        {
            get
            {
                return _chartView;
            }
        }
        private ManualViewModel _manualViewModel;
        private SetupViewModel _setupViewModel;
        private object _contentMainViewModel;
        public object ContentMainViewModel
        {
            get { return _contentMainViewModel; }
            private set { if (_contentMainViewModel != value) { _contentMainViewModel = value; OnChanged(""); } }
        }
        public MainWindowViewModel(MainSystem mainSystem)
        {
            _mainSystem = mainSystem;
            _dispatcher = Application.Current.Dispatcher;

            _mainOpViewModel = new MainOpViewModel(_mainSystem, this);
            _mainSectionViewModel = new MainSectionViewModel();
            _mainLogViewModel = new MainLogViewModel();

            _chartViewModel = new ChartViewModel();
            _manualViewModel = new ManualViewModel();
            _setupViewModel = new SetupViewModel();

            ContentMainViewModel = _chartViewModel;
            ContentOpViewModel = _mainOpViewModel;
            ContentSectionViewModel = _mainSectionViewModel;
            ContentLogViewModel = _mainLogViewModel;

            _mainSystem.MainSectionViewModel = _mainSectionViewModel;
            _mainSystem.SetStateSystem(State.IDL);
        }

        public void Initialize()
        {
        }

        public void ContentChart_Changed()
        {
            this.ContentMainViewModel = _chartViewModel;
        }
        public void ContentManual_Changed()
        {
            this.ContentMainViewModel = _manualViewModel;
        }
        public void ContentSetup_Changed()
        {
            this.ContentMainViewModel = _setupViewModel;
        }
    }
}
