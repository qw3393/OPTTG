using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTG.Models;

namespace TTG.ViewModels
{
    public class MainOpViewModel : ViewModelBase
    {
        private RelayCommand _mainCommand;
        public RelayCommand MainCommand
        {
            get
            {
                //if (_mainCommand == null)
                //    _mainCommand = new RelayCommand(() => Plot());
                return _mainCommand;
            }
        }
        private RelayCommand _startCommand;
        public RelayCommand StartCommand
        {
            get
            {
                //if (_startCommand == null)
                //    _startCommand = new RelayCommand(() => Plot());
                return _startCommand;
            }
        }
        private RelayCommand _stopCommand;
        public RelayCommand StopCommand
        {
            get
            {
                //if (_stopCommand == null)
                //    _stopCommand = new RelayCommand(() => Plot());
                return _stopCommand;
            }
        }
        private RelayCommand _setupCommand;
        public RelayCommand SetupCommand
        {
            get
            {
                //if (_setupCommand == null)
                //    _setupCommand = new RelayCommand(() => Plot());
                return _setupCommand;
            }
        }
        private RelayCommand _manualCommand;
        public RelayCommand ManualCommand
        {
            get
            {
                //if (_manualCommand == null)
                //    _manualCommand = new RelayCommand(() => Plot());
                return _manualCommand;
            }
        }
        private RelayCommand _exitCommand;
        public RelayCommand ExitCommand
        {
            get
            {
                //if (_exitCommand == null)
                //    _exitCommand = new RelayCommand(() => Plot());
                return _exitCommand;
            }
        }
        public MainOpViewModel()
        {
        }
    }
}
