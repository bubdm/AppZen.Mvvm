using System;
using System.Threading.Tasks;
using AppZen.Mvvm.Core.Interfaces;

namespace AppZen.Mvvm.Core.Implementations
{
    public class BaseViewModel<TInitParams> : IViewModel, IDisposable
    {
        public BaseViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        public IViewFactory FormFactory { get; set; }
        public event EventHandler<EventArgs> Initialised = delegate { };
        public bool IsInitialised { get; set; }

        public string Id { get; set; }
        private TInitParams _InitParams;


        public async Task Init(object parameters)
        {
            _InitParams = (TInitParams)parameters;

            await Initialize(_InitParams);
            IsInitialised = true;
            Initialised?.Invoke(this, new EventArgs());
        }

        public virtual async Task Initialize(TInitParams arguments)
        {
            await Task.Run(() => { });
        }

        public void Close()
        {
            FormFactory.CloseView(this.Id);
        }
        public async Task ShowViewModel<T>(object arguments) where T : IViewModel
        {
            await FormFactory.ShowViewModel<T>(arguments);
        }

        public async Task ShowViewModel<T>() where T : IViewModel
        {
            await FormFactory.ShowViewModel<T>(null);
        }


        public virtual void Dispose()
        {

        }
    }
}