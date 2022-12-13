using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTG.Models
{
    public class HMot
    {
        public HMot()
        {
        }
        public void Initialize()
        {
            if (!_isInit)
                initLibrary();
        }
        private static bool _isInit = false;
        public  bool IsInit
        {
            get { return _isInit; }
        }
        private void initLibrary()
        {
            _isInit = false;
            try
            {
                //++ AXL(AjineXtek Library)을 사용가능하게 하고 장착된 보드들을 초기화합니다.
                uint uAxlOpen = CAXL.AxlOpen(7);
                if (uAxlOpen != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS && uAxlOpen != (uint)AXT_FUNC_RESULT.AXT_RT_OPEN_ALREADY)
                {
                    return;
                }
                String szFilePath = "MotionDefault.mot";
                //++ 지정한 Mot파일의 설정값들로 모션보드의 설정값들을 일괄변경 적용합니다.
                if (CAXM.AxmMotLoadParaAll(szFilePath) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    return;
                }
                _isInit = true;
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
