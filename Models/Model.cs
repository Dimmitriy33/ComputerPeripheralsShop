using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ComputerPeripheralsShop.Models
{
    public abstract class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        //обновление нескольких свойств(например)
        protected virtual bool set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value))
                return false;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
