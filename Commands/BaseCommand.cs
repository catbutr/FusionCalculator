using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FusionCalculator.Commands
{
    public abstract class BaseCommand
    {
        ///// <summary>
        ///// Доступна ли команда.
        ///// </summary>
        ///// <param name="parameter"> DataContext для команды. </param>
        ///// <returns> True - доступна. </returns>
        //public virtual bool CanExecute(object parameter)
        //{
        //    return true;
        //}

        ///// <summary>
        ///// Событие выполнения.
        ///// </summary>
        //public event EventHandler CanExecuteChanged
        //{
        //    add => CommandManager.RequerySuggested += value;
        //    remove => CommandManager.RequerySuggested -= value;
        //}


        ///// <summary>
        ///// Выполнение команды.
        ///// </summary>
        ///// <param name="parameter"> DataContext для команды. </param>
        //public abstract void Execute(object parameter);

        ///// <summary>
        ///// Вызывает событие изменения возможности вызвать команду.
        ///// </summary>
        //[Obsolete("Теперь обновление состояния происходит при помощи " +
        //          nameof(CommandManager) + "." + nameof(CommandManager.RequerySuggested))]
        //public void RaiseCanExecuteChanged()
        //{
        //}
    }
}
