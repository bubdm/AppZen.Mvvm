using System;

namespace AppZen.Mvvm.Core.Interfaces
{
    public interface IView
    {
        IViewModel ViewModel { get; }
        bool? ShowViewDialog();
        void ShowView();
        void CloseView();
        Action CloseAction { get; set; }
    }
}