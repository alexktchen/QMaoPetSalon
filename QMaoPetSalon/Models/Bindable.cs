using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QMaoPetSalon.Models
{
    public abstract class Bindable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T aStorage, T aValue, [CallerMemberName] String aPropertyName = null)
        {
            if (object.Equals(aStorage, aValue))
                return false;

            aStorage = aValue;
            OnPropertyChanged(aPropertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string aPropertyName = null)
        {
            var eventHandler = PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(aPropertyName));
            }
        }
    }
}
