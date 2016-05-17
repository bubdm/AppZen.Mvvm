using AppZen.Mvvm.Core.Interfaces;

namespace AppZen.Mvvm.Core
{
    public class App : IApp
    {
        public App(IContainer container)
        {
            Container = container;
        }

        public static IContainer Container = null;

        public virtual void Start()
        {
            
        }
    }
}
