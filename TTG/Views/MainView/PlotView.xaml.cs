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

namespace TTG.Views.MainView
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PlotView : UserControl
    {
        private PlotViewModel _viewModel;
        private Dispatcher _dispatcher;
        public PlotView()
        {
            InitializeComponent();
        }
        public PlotView(Dispatcher dispatcher)
        {
            InitializeComponent();
            _dispatcher = dispatcher;
        }

        public void UpdateViewModel(PlotViewModel ViewModel)
        {
            _dispatcher.Invoke(delegate () { this.UpdateDataContext(ViewModel); });
        }
        private void UpdateDataContext(PlotViewModel ViewModel)
        {
            _viewModel = ViewModel;
            this.DataContext = _viewModel;
        }
    }
}
