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
        private MainSystem _mainSystem;
        private MainWindowViewModel _mainWindowViewModel;

        private RelayCommand _mainCommand;
        public RelayCommand MainCommand
        {
            get
            {
                if (_mainCommand == null)
                    _mainCommand = new RelayCommand(() => _mainWindowViewModel.ContentChart_Changed());
                return _mainCommand;
            }
        }
        private RelayCommand _startCommand;
        public RelayCommand StartCommand
        {
            get
            {
                if (_startCommand == null)
                    _startCommand = new RelayCommand(() => _mainSystem.Run());
                return _startCommand;
            }
        }
        private RelayCommand _stopCommand;
        public RelayCommand StopCommand
        {
            get
            {
                if (_stopCommand == null)
                    _stopCommand = new RelayCommand(() => _mainSystem.SetStateSystem(State.IDL));
                return _stopCommand;
            }
        }
        private RelayCommand _setupCommand;
        public RelayCommand SetupCommand
        {
            get
            {
                if (_setupCommand == null)
                    _setupCommand = new RelayCommand(() => _mainWindowViewModel.ContentSetup_Changed());
                return _setupCommand;
            }
        }
        private RelayCommand _manualCommand;
        public RelayCommand ManualCommand
        {
            get
            {
                if (_manualCommand == null)
                    _manualCommand = new RelayCommand(() => _mainWindowViewModel.ContentManual_Changed());
                return _manualCommand;
            }
        }
        private RelayCommand _exitCommand;
        public RelayCommand ExitCommand
        {
            get
            {
                if (_exitCommand == null)
                    _exitCommand = new RelayCommand(() => _mainSystem.Close());
                return _exitCommand;
            }
        }
        public MainOpViewModel(MainSystem mainSystem, MainWindowViewModel mainWindowViewModel)
        {
            _mainSystem = mainSystem;
            _mainWindowViewModel = mainWindowViewModel;
        }
    }
}
