using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Input;
using TTG.ViewModels;

namespace TTG.Models
{
    public enum State
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

    public class MainSystem : ViewModelBase
    {
        private bool _sw_Simulation;
        public bool SW_Simulation
        {
            get { return _sw_Simulation; }
        }
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
        private State _stateSystem;
        private MainSectionViewModel _mainSectionViewModel;
        public MainSectionViewModel MainSectionViewModel
        {
            get { return _mainSectionViewModel; }
            set { if (_mainSectionViewModel != value) { _mainSectionViewModel = value; OnChanged(""); } }
        }
        private MeasurementEngine _measurementEngine;
        public MainSystem()
        {
            //Initialize();
        }

        ~MainSystem()
        {
            Dispose(false);
        }

        public void Initialize()
        {
            _hIO = new HIO();
            _hMot = new HMot();
            _hCHR = new HCHR();

            _sw_Simulation = Convert.ToBoolean(ConfigurationManager.AppSettings["bsimul"]);
            _measurementEngine = new MeasurementEngine(this);
        }
        public void Run()
        {
            _measurementEngine.StartMeasurementEngine();
        }
        public void SetStateSystem(State state)
        {
            _stateSystem = state;
            _mainSectionViewModel.SetTextState(state);
        }
        public State GetStateSystem()
        {
            return _stateSystem;
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
