using System;
using System.Windows.Forms;
using AppZen.Mvvm.Windows.Extensions;

namespace AppZen.Mvvm.Windows.Implemetations
{
    public interface IViewPresenter
    {
        event EventHandler<EventArgsHandled<Form>> OpenForm;
        void OnFormLoaded(EventArgsHandled<Form> args);
    }

    public class Presenter : IViewPresenter
    {
        public event EventHandler<EventArgsHandled<Form>> OpenForm = delegate { };
        public void OnFormLoaded(EventArgsHandled<Form> args)
        {
            OpenForm?.Invoke(this, args);
        }
    }
}