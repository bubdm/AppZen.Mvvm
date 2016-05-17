using System.Windows.Forms;
using AppZen.Mvvm.Core;
using AppZen.Mvvm.Core.Interfaces;
using AppZen.Mvvm.Windows.Interfaces;

namespace AppZen.Mvvm.Windows.Implemetations
{
    public class WinformsApp : App
    {
        private readonly IContainer _container;
        private Form _mainForm = null;
        public void InitialiseApp()
        {
            
            if (_mainForm == null)
            {
                _mainForm = Container.Resolve<IMainForm>().Form;
            }
        }

        public Form MainForm
        {
            get
            {
                return _mainForm;
            }
        }


        public WinformsApp(IContainer container) : base(container)
        {
            _container = container;
        }

        public override void Start()
        {
            
        }
    }
}