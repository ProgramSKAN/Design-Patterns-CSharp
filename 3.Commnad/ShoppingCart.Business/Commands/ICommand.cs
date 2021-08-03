using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Business.Commands
{
    //ICoomand also exists in Sytem.Windows.Input.ICommand which is recommanded if you are working in UI application (WPF)
    public interface ICommand
    {
        void Execute();
        bool CanExecute();//check whether command can be executed or not
        void Undo();
    }
}
