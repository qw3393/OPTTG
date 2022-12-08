using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTG.ViewModels;

namespace TTG.Models
{
    public class MainApp : ViewModelBase
    {
        private MainSystem _mainSystem;

        public MainSystem MainSystem
        {
            get { return _mainSystem; }
            set { if (_mainSystem != value) { _mainSystem = value; } }
        }
        public MainApp()
        {
            _mainSystem = new MainSystem();
        }
    }
}
