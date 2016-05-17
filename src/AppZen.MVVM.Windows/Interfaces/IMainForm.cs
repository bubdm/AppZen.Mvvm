using System.Windows.Forms;
using AppZen.Mvvm.Core.Interfaces;

namespace AppZen.Mvvm.Windows.Interfaces
{
    public interface IMainForm : IView
    {
        Form Form { get;  }
    }
}
