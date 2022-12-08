using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTG.Models;

namespace TTG.ViewModels
{
    public class SystemInitViewModel : ViewModelBase
    {
        public SystemInitViewModel()
        {
            SetText();
        }
        private HMot _hMot;
        private HIO _hIO;
        private HCHR _hCHR;
        private string _initIO;
        public string InitIO
        {
            get { return _initIO; }
            set
            {
                if (_initIO != value)
                {
                    _initIO = value;
                    OnChanged("InitIO");
                }
            }
        }
        private string _initMot;
        public string InitMot
        {
            get { return _initMot; }
            set
            {
                if (_initMot != value)
                {
                    _initMot = value;
                    OnChanged("InitMot");
                }
            }
        }
        private string _initCHR;
        public string InitCHR
        {
            get { return _initCHR; }
            set
            {
                if (_initCHR != value)
                {
                    _initCHR = value;
                    OnChanged("InitCHR");
                }
            }
        }
        private void SetText()
        {
            _hMot = new HMot();
            _hIO = new HIO();
            _hCHR = new HCHR();

            if (_hIO.IsInit)
            {
                InitIO = "I/O Board Init. Completed ...";
            }
            else
            {
                InitIO = "I/O Board Init. Failed ...";
            }
            if (_hMot.IsInit)
            {
                InitMot = "Motion Board Init. Completed...";
            }
            else
            {
                InitMot = "Motion Board Init. Failed ...";
            }
            if (_hCHR.IsInit)
            {
                InitCHR = "Sensor Init.Completed...";
            }
            else
            {
                InitCHR = "Sensor Init. Failed ...";
            }
        }
    }
}
