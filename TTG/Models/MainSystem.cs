using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TTG.ViewModels;

namespace TTG.Models
{
    public class MainSystem : ViewModelBase
    {
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
        }
        public void Close()
        {
            if (_hIO.IsInit)
                _hIO.Dispose();
            if (_hMot.IsInit)
                _hMot.Dispose();
            if (_hCHR.IsInit)
                _hCHR.Dispose();
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
