using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTG.Models
{
    public class HCHR
    {
        uint CHRHandle;
        public HCHR()
        {
            Initialize();
        }
        private void Initialize()
        {
            if (!_isInit)
                initLibrary();
        }
        private static bool _isInit = false;
        public bool IsInit
        {
            get { return _isInit; }
        }
        private void initLibrary()
        {
            bool bConnect = false;
            _isInit = false;
            int DeviceType = TCHRDLLFunctionWrapper.CHR_2Gen_Device;
            string strConInfo = "IP:192.168.170.2";

            int nTemp;
            bConnect = TCHRDLLFunctionWrapper.OpenConnection(strConInfo, DeviceType, out nTemp) == 0;
            if (bConnect)
            {
                CHRHandle = Convert.ToUInt32(nTemp);
                SetupDevice();
                _isInit = true;
            }
            else
            {
                _isInit = false;
            }
        }
        public void SetupDevice()
        {

        }
        public void Close()
        {
            if (_isInit)
                TCHRDLLFunctionWrapper.CloseConnection(CHRHandle);
        }
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
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
