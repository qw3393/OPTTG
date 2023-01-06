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

namespace TTG
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _mainWindowViewModel;
        private Dispatcher _dispatcher;
        public MainWindow()
        {
            InitializeComponent();
            _dispatcher = Application.Current.Dispatcher;
        }
        public void SetViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _dispatcher.Invoke(delegate () { this.SetDataContext(mainWindowViewModel); });
        }
        public void SetDataContext(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            this.DataContext = mainWindowViewModel;
        }
    }
}
