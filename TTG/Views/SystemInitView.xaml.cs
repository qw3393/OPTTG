using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TTG.ViewModels;
using TTG.ViewModels.MainView;

namespace TTG.Views
{
    /// <summary>
    /// SystemInitView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SystemInitView : Window
    {
        private SystemInitViewModel _systemInitViewModel;
        private Dispatcher _dispatcher;
        public SystemInitView()
        {
            InitializeComponent();
            _dispatcher = Application.Current.Dispatcher;
            _systemInitViewModel = new SystemInitViewModel();
            SetViewModel(_systemInitViewModel);

            _systemInitViewModel.OnRequestClose += (s, e) => this.Close();

            this.ShowDialog();
        }

        public void SetViewModel(SystemInitViewModel systemInitViewModel)
        {
            _dispatcher.Invoke(delegate () { this.SetDataContext(systemInitViewModel); });
        }
        public void SetDataContext(SystemInitViewModel systemInitViewModel)
        {
            //_systemInitViewModel = systemInitViewModel;
            this.DataContext = systemInitViewModel;
        }
    }
}
