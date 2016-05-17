using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppZen.Mvvm.Core.Interfaces;

namespace AppZen.Mvvm.Windows.Implemetations
{
    public class BaseForm: Form,IView 
    {
        private readonly IViewModel _viewModel;
        public IViewModel ViewModel { get { return _viewModel; } }

        public BaseForm()
        {
        }

        public BaseForm(IViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.Initialised += _viewModel_OnInitialised;
        }

        async void _viewModel_OnInitialised(object sender, EventArgs e)
        {
            _viewModel.Initialised -= _viewModel_OnInitialised;

            AddControls();
            await DataBindAsync();
        }


        public virtual void AddControls()
        {
        }

        public virtual Task DataBindAsync()
        {
            return new Task(() => { });
        }

        public bool? ShowViewDialog()
        {
            return ShowDialog() == DialogResult.OK;
        }

        public void ShowView()
        {
            this.Show();
        }

        public virtual void CloseView()
        {
            this.Close();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (CloseAction != null)
            {
                e.Cancel = true;
                CloseAction.Invoke();
            }
            base.OnFormClosing(e);
        }

        public Action CloseAction { get; set; }
    }
}
