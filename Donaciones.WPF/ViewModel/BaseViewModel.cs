using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Donaciones.WPF {
    public abstract class BaseViewModel :INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Set<T>(ref T target,T value,[CallerMemberName] string propertyName = "") {
            target = value;
            RaisePropertyChanged(propertyName);
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }
}
