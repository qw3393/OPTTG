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
        }
        private static string _initIO;
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
        private static string _initMot;
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
        private static string _initCHR;
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
        public void SetText(bool bInitIO, bool bInitMot, bool bInitCHR)
        {
            if (bInitIO)
            {
                InitIO = "I/O Board Init. Completed ...";
            }
            else
            {
                InitIO = "I/O Board Init. Failed ...";
            }
            if (bInitMot)
            {
                InitMot = "Motion Board Init. Completed...";
            }
            else
            {
                InitMot = "Motion Board Init. Failed ...";
            }
            if (bInitCHR)
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
