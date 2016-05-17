using System.Windows.Forms;
using AppZen.Mvvm.Core.Interfaces;
using AppZen.Mvvm.Windows.Interfaces;

namespace AppZen.Mvvm.Windows.Implemetations
{
    public class BaseUserControl : UserControl, IUserControl
    {
        public Control Control => this;
    }

    public class BaseFormSingleton : BaseForm
    {
        public BaseFormSingleton()
        {
        }

        public BaseFormSingleton(IViewModel viewModel):base(viewModel)
        {
        }

        public override void CloseView()
        {
            if (this.Visible)
            {
                this.Hide();
            }
        }
    }
}