using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FusionCalculator.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Поле свойства <see cref="IsDataValid" />.
        /// </summary>
        private bool _isDataValid = true;

        /// <summary>
        /// Правильно ли введены значения.
        /// </summary>
        public bool IsDataValid
        {
            get => _isDataValid;
            set
            {
                _isDataValid = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Событие, генерируемое при изменении свойств.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод генерации события при изменении определенного свойства.
        /// </summary>
        /// <param name="propertyName"> Имя свойства. </param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
