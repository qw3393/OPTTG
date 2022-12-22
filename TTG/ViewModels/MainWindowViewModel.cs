using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TTG.ViewModels.MainView;
using TTG.Views;
using TTG.Views.MainView;

namespace TTG.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Dispatcher _dispatcher;

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
            private set { if (_contentOpViewModel != value) { _contentOpViewModel = value; } OnChanged(""); }
        }

        private PlotViewModel _plotViewModel;
        private PlotView _plotView;
        public System.Windows.Controls.UserControl PlotView
        {
            get
            {
                return _plotView;
            }
        }
        private ManualViewModel _manualViewModel;
        private SetupViewModel _setupViewModel;
        private object _contentMainViewModel;
        public object ContentMainViewModel
        {
            get { return _contentMainViewModel; }
            private set { if (_contentMainViewModel != value) { _contentMainViewModel = value; } OnChanged(""); }
        }
        public MainWindowViewModel()
        {
            _dispatcher = Application.Current.Dispatcher;

            //_mainOpView = new MainOpView(_dispatcher);
            _mainOpViewModel = new MainOpViewModel();
            //_mainOpView.UpdateViewModel(_mainOpViewModel);

            //_plotView = new PlotView(_dispatcher);
            _plotViewModel = new PlotViewModel();
            //_plotView.UpdateViewModel(_plotViewModel);

            _manualViewModel = new ManualViewModel();
            _setupViewModel = new SetupViewModel();
            

            ContentOpViewModel = _mainOpViewModel;
            ContentMainViewModel = _plotViewModel;
        }
    }
}
