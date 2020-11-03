using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;

namespace Neydarsimi.Helper
{
    public enum EMessageTargetType
    {
        None,
        Information,
        Warning,
        Error
    }

    public enum EResponseTargetType
    {
        YesNo = 1,
        OkCancel
    }
    public class ViewModelBase : INotifyPropertyChanged
    {
        private bool _isDirty = false;

        public Action<String, String, EMessageTargetType> MessageTarget { get; set; }
        public Func<string, string, EResponseTargetType, EMessageTargetType, bool> ResponseTarget { get; set; }
        //basic ViewModelBase
        internal void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        //Extra Stuff, shows why a base ViewModel is useful
        bool? _CloseWindowFlag;
        public bool? CloseWindowFlag
        {
            get { return _CloseWindowFlag; }
            set
            {
                _CloseWindowFlag = value;
                NotifyPropertyChanged("CloseWindowFlag");
            }
        }

        public bool IsDirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (Equals(storage, value))
                return false;

            _isDirty = true;
            storage = value;
            this.NotifyPropertyChanged(propertyName);
            return true;
        }

        public virtual void CloseWindow(bool? result = true)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                CloseWindowFlag = CloseWindowFlag == null
                    ? true
                    : !CloseWindowFlag;
            }));
        }
    }
}
