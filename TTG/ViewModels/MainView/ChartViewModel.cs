using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Configurations;

namespace TTG.ViewModels.MainView
{
    public class ChartViewModel : ViewModelBase
    {
        private ChartValues<float> _resultChartValues01;
        public ChartValues<float> ResultChartValues01
        {
            get
            {
                return _resultChartValues01;
            }
            set
            {
                if (_resultChartValues01 != value)
                {
                    _resultChartValues01 = value;
                    OnChanged("ResultChartValues01");
                }
            }
        }
        private ChartValues<float> _resultChartValues02;
        public ChartValues<float> ResultChartValues02
        {
            get
            {
                return _resultChartValues02;
            }
            set
            {
                if (_resultChartValues02 != value)
                {
                    _resultChartValues02 = value;
                    OnChanged("ResultChartValues02");
                }
            }
        }
        private ChartValues<float> _resultChartValues03;
        public ChartValues<float> ResultChartValues03
        {
            get
            {
                return _resultChartValues03;
            }
            set
            {
                if (_resultChartValues03 != value)
                {
                    _resultChartValues03 = value;
                    OnChanged("ResultChartValues03");
                }
            }
        }
        private ChartValues<float> _resultChartValues04;
        public ChartValues<float> ResultChartValues04
        {
            get
            {
                return _resultChartValues04;
            }
            set
            {
                if (_resultChartValues04 != value)
                {
                    _resultChartValues04 = value;
                    OnChanged("ResultChartValues04");
                }
            }
        }
        private ChartValues<float> _resultChartValues05;
        public ChartValues<float> ResultChartValues05
        {
            get
            {
                return _resultChartValues05;
            }
            set
            {
                if (_resultChartValues05 != value)
                {
                    _resultChartValues05 = value;
                    OnChanged("ResultChartValues05");
                }
            }
        }
        private ChartValues<float> _resultChartValues06;
        public ChartValues<float> ResultChartValues06
        {
            get
            {
                return _resultChartValues06;
            }
            set
            {
                if (_resultChartValues06 != value)
                {
                    _resultChartValues06 = value;
                    OnChanged("ResultChartValues06");
                }
            }
        }

        private ChartValues<float> _liveChartValues01;
        public ChartValues<float> LiveChartValues01
        {
            get
            {
                return _liveChartValues01;
            }
            set
            {
                if (_liveChartValues01 != value)
                {
                    _liveChartValues01 = value;
                    OnChanged("LiveChartValues01");
                }
            }
        }
        private ChartValues<float> _liveChartValues02;
        public ChartValues<float> LiveChartValues02
        {
            get
            {
                return _liveChartValues02;
            }
            set
            {
                if (_liveChartValues02 != value)
                {
                    _liveChartValues02 = value;
                    OnChanged("LiveChartValues02");
                }
            }
        }
        private ChartValues<float> _liveChartValues03;
        public ChartValues<float> LiveChartValues03
        {
            get
            {
                return _liveChartValues03;
            }
            set
            {
                if (_liveChartValues03 != value)
                {
                    _liveChartValues03 = value;
                    OnChanged("LiveChartValues03");
                }
            }
        }
        private ChartValues<float> _liveChartValues04;
        public ChartValues<float> LiveChartValues04
        {
            get
            {
                return _liveChartValues04;
            }
            set
            {
                if (_liveChartValues04 != value)
                {
                    _liveChartValues04 = value;
                    OnChanged("LiveChartValues04");
                }
            }
        }
        private ChartValues<float> _liveChartValues05;
        public ChartValues<float> LiveChartValues05
        {
            get
            {
                return _liveChartValues05;
            }
            set
            {
                if (_liveChartValues05 != value)
                {
                    _liveChartValues05 = value;
                    OnChanged("LiveChartValues05");
                }
            }
        }
        private ChartValues<float> _liveChartValues06;
        public ChartValues<float> LiveChartValues06
        {
            get
            {
                return _liveChartValues06;
            }
            set
            {
                if (_liveChartValues06 != value)
                {
                    _liveChartValues06 = value;
                    OnChanged("LiveChartValues06");
                }
            }
        }

        public ChartViewModel()
        {
            var r = new Random();
            float[] fData = new float[50];
            float[] fData2 = new float[10];
            for (int i = 0; i< fData.Length; i++) 
            {
                fData[i] = r.Next(-4, 4) + 500;
            }
            ResultChartValues01 = new ChartValues<float>(fData);

            for (int i = 0; i < fData.Length; i++)
            {
                fData[i] = r.Next(-4, 4) + 500;
            }
            ResultChartValues02 = new ChartValues<float>(fData);

            for (int i = 0; i < fData.Length; i++)
            {
                fData[i] = r.Next(-4, 4) + 500;
            }
            ResultChartValues03 = new ChartValues<float>(fData);

            for (int i = 0; i < fData.Length; i++)
            {
                fData[i] = r.Next(-4, 4) + 500;
            }
            ResultChartValues04 = new ChartValues<float>(fData);

            for (int i = 0; i < fData.Length; i++)
            {
                fData[i] = r.Next(-4, 4) + 500;
            }
            ResultChartValues05 = new ChartValues<float>(fData);

            for (int i = 0; i < fData.Length; i++)
            {
                fData[i] = r.Next(-4, 4) + 500;
            }
            ResultChartValues06 = new ChartValues<float>(fData);

            for (int i = 0; i < fData2.Length; i++)
            {
                fData2[i] = r.Next(-4, 4) + 500;
            }
            LiveChartValues01 = new ChartValues<float>(fData2);

            for (int i = 0; i < fData2.Length; i++)
            {
                fData2[i] = r.Next(-4, 4) + 500;
            }
            LiveChartValues02 = new ChartValues<float>(fData2);

            for (int i = 0; i < fData2.Length; i++)
            {
                fData2[i] = r.Next(-4, 4) + 500;
            }
            LiveChartValues03 = new ChartValues<float>(fData2);

            for (int i = 0; i < fData2.Length; i++)
            {
                fData2[i] = r.Next(-4, 4) + 500;
            }
            LiveChartValues04 = new ChartValues<float>(fData2);

            for (int i = 0; i < fData2.Length; i++)
            {
                fData2[i] = r.Next(-4, 4) + 500;
            }
            LiveChartValues05 = new ChartValues<float>(fData2);

            for (int i = 0; i < fData2.Length; i++)
            {
                fData2[i] = r.Next(-4, 4) + 500;
            }
            LiveChartValues06 = new ChartValues<float>(fData2);
        }
    }
}
