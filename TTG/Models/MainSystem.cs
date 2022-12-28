using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TTG.ViewModels;

namespace TTG.Models
{
    public class MainSystem : ViewModelBase
    {
        enum State
        {
            NONE,
            IDL,
            MEA,
            MANUAL,
            ENGINEERING,
            SIMUL,
            ERROR,
            RESET
        }
        private const bool SW_Simulation = false;

        private HIO _hIO;
        public HIO HIO
        {
            get { return _hIO; }
            set { if (_hIO != value) { _hIO = value; } OnChanged(""); }
        }
        private HMot _hMot;
        public HMot HMot
        {
            get { return _hMot; }
            set { if (_hMot != value) { _hMot = value; } OnChanged(""); }
        }
        private HCHR _hCHR;
        public HCHR HCHR
        {
            get { return _hCHR; }
            set { if (_hCHR != value) { _hCHR = value; } OnChanged(""); }
        }
        private SystemInitViewModel _systemInitViewModel;
        public SystemInitViewModel SystemInitViewModel
        {
            get { return _systemInitViewModel; }
            set { if (_systemInitViewModel != value) { _systemInitViewModel = value; } OnChanged(""); }
        }
        public MainSystem()
        {
            Initialize();
        }

        ~MainSystem()
        {
            Dispose(false);
        }

        private void Initialize()
        {
            _hIO = new HIO();
            _hMot = new HMot();
            _hCHR = new HCHR();
            _systemInitViewModel = new SystemInitViewModel();

            if (!SW_Simulation)
            {
                _hIO.Initialize();
                _hMot.Initialize();
                _hCHR.Initialize();
                _systemInitViewModel.SetText(_hIO.IsInit, _hMot.IsInit, _hCHR.IsInit);
            }
            else
            {
                _systemInitViewModel.SetText(true , true, true);
            }
        }

        public void Close()
        {
            MessageBoxResult mbr = MessageBox.Show("Terminate Program?","TTG App", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (mbr == MessageBoxResult.Yes)
            {
                if (_hIO != null && _hIO.IsInit)
                    _hIO.Dispose();
                if (_hMot != null && _hMot.IsInit)
                    _hMot.Dispose();
                if (_hCHR != null && _hCHR.IsInit)
                    _hCHR.Dispose();
                Application.Current.Shutdown();
            }
        }
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if(!disposedValue)
            {
                if(disposing)
                {
                    this.Close();
                }
            }
            disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
