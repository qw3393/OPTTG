using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTG.Models
{
    public class HIO
    {
        public HIO()
        {
        }
        public void Initialize()
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
            _isInit = false;
            try
            {
                uint uAxlOpen = CAXL.AxlOpen(7);
                //++ AXL(AjineXtek Library)을 사용가능하게 하고 장착된 보드들을 초기화합니다.
                if (uAxlOpen == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS || uAxlOpen == (uint)AXT_FUNC_RESULT.AXT_RT_OPEN_ALREADY)
                {
                    uint uStatus = 0;
                    if (CAXD.AxdInfoIsDIOModule(ref uStatus) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                    {
                        if ((AXT_EXISTENCE)uStatus == AXT_EXISTENCE.STATUS_EXIST)
                        {
                            int nModuleCount = 0;
                            if (CAXD.AxdInfoGetModuleCount(ref nModuleCount) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                            {
                                uint uModuleID = 0;
                                if ((AXT_MODULE)uModuleID == AXT_MODULE.AXT_SIO_DB32T)
                                {
                                    _isInit = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _isInit = false;
            }
        }
        public void Close()
        {
            if (_isInit && CAXL.AxlIsOpened() == 1)
            {
                CAXL.AxlClose();
            }
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
