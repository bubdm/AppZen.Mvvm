using System;
using System.Threading.Tasks;

namespace AppZen.Mvvm.Core.Interfaces
{
    public interface IViewModel
    {
        event EventHandler<EventArgs> Initialised;
        bool IsInitialised { get; set; }
        string Id { get; set; }
        Task Init(object parameters);
    }
}