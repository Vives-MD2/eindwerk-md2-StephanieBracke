using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VidyaBase.UI.ViewModels
{
    public struct GetParam
    {
        public int UserId;
        public int Skip;
        public int Take;
    }

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;

            backingField = value;

            OnPropertyChanged(propertyName);
        }
    }
}
