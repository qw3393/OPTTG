using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TTG.Views;

namespace TTG.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private MainOpViewModel _mainOpViewModel;
        private MainOpView _mainOpView;
        private Dispatcher _dispatcher;
        public System.Windows.Controls.UserControl MainOpView
        {
            get
            {
                return _mainOpView;
            }
        }
        private object _contentViewModel;
        public object ContentViewModel
        {
            get { return _contentViewModel; }
            private set { if (_contentViewModel != value) { _contentViewModel = value; } OnChanged(""); }
        }
        public MainWindowViewModel()
        {
            _dispatcher = Application.Current.Dispatcher;
            _mainOpView = new MainOpView(_dispatcher);
            _mainOpViewModel = new MainOpViewModel();
            _mainOpView.UpdateViewModel(_mainOpViewModel);

            ContentViewModel = _mainOpViewModel;
        }
    }
}
