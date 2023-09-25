using System.Collections.Generic;
using System.ComponentModel;

namespace FlightsWPF.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(params string[] propertyName)
        {
            foreach (string prop in propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }

        private Dictionary<string, object> backingFields = new Dictionary<string, object>();

        protected T GetValue<T>(string propertyName, T defaultValue = default)
        {
            if (!backingFields.ContainsKey(propertyName))
                backingFields[propertyName] = defaultValue;

            return (T)backingFields[propertyName];
        }

        protected bool SetValue<T>(string propertyName, object value)
        {
            if (backingFields.ContainsKey(propertyName) || backingFields[propertyName] != value)
            {
                backingFields[propertyName] = value;
                NotifyPropertyChanged(propertyName);
                return true;
            }

            return false;
        }
    }
}
