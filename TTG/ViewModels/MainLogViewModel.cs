using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Appender;
using log4net;
using log4net.Core;
using System.ComponentModel;
using TTG.Models;
using System.Globalization;
using System.IO;

namespace TTG.ViewModels
{
    public class MainLogViewModel : AppenderSkeleton, INotifyPropertyChanged
    {
        #region Members and events
        private static List<string> _notification;
        private event PropertyChangedEventHandler _propertyChanged;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add { _propertyChanged += value; }
            remove { _propertyChanged -= value; }
        }
        #endregion
        public List<string> Notification
        {
            get
            {
                return _notification; ;
            }
            set
            {
                if (_notification != value)
                {
                    _notification = value;
                    OnChange();
                }
            }
        }
        private void OnChange()
        {
            PropertyChangedEventHandler handler = _propertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(string.Empty));
            }
        }
        public MainLogViewModel()
        {

        }
        public MainLogViewModel Appender
        {
            get
            {
                return Log.Appender;
            }
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            StringWriter writer = new StringWriter(CultureInfo.InvariantCulture);
            Layout.Format(writer, loggingEvent);
            if(Notification.Count>50)
            {
                Notification.RemoveAt(0);
                Notification.Add(writer.ToString());

            }
            else
            {
                Notification.Add(writer.ToString());
            }
        }

    }
}
