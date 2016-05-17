using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppZen.Mvvm.Core.Interfaces;
using AppZen.Mvvm.Windows.Extensions;

#pragma warning disable 4014

namespace AppZen.Mvvm.Windows.Implemetations
{
    public class ViewFactory : IViewFactory
    {
        public IViewPresenter Presenter { get; set; }
        public IViewResolver ViewResolver { get; set; }
        public IContainer Container { get; set; }

        public void CloseView(string id)
        {
            var views = (from Form openForm in Application.OpenForms
                         select openForm as IView).ToList();

            var viewToClose = views.FirstOrDefault(view =>
                    view?.ViewModel != null && view.ViewModel.Id == id);

            viewToClose?.CloseView();
        }


        public async Task ShowViewModel<T>(object argumentsAsAnonymousType) where T : IViewModel
        {
            var viewInterface = FindFormInterface<T>();
            if (viewInterface != null)
            {
                var resolvedForm = Container.Resolve(viewInterface) as IView;
                if (resolvedForm != null)
                {
                    resolvedForm.CloseAction = () => Container.Release(resolvedForm);
                    resolvedForm.ViewModel?.Init(argumentsAsAnonymousType);

                    var args = new EventArgsHandled<Form>(resolvedForm as Form);
                    Presenter.OnFormLoaded(args);

                    if (!args.Handled)
                    {
                        resolvedForm.ShowView();
                    }
                }
            }
            else
            {
                MessageBox.Show($"View for ViewModel :{typeof(T).Name} not found");
            }
        }

        public Task ShowViewModel<T>() where T : IViewModel
        {
            return ShowViewModel<T>(null);
        }

        private Type FindFormInterface<T>()
        {
            var viewName = typeof(T).Name.Replace("ViewModel", "");
            viewName = typeof (T).IsInterface ? viewName.Remove(0, 1) : viewName;

            var form = ViewResolver.Views.FirstOrDefault(i => i.Name == viewName || i.Name == viewName + "View");

            var formInterface = form?.GetInterfaces().SingleOrDefault(p => typeof(IView).IsAssignableFrom(p) && typeof(IView).FullName != p.FullName);
            return formInterface;
        }

    }
}
