using System.Threading.Tasks;

namespace AppZen.Mvvm.Core.Interfaces
{
    public interface IViewFactory
    {
        void CloseView(string id);
        Task ShowViewModel<T>(object argumentsAsAnonymousType) where T : IViewModel;
        Task ShowViewModel<T>() where T : IViewModel;
    }
}