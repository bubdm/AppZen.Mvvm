using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AppZen.Mvvm.Core.Interfaces;
using AppZen.Mvvm.Windookupows.Extensions;

namespace AppZen.Mvvm.Windows.Implemetations
{
    public class ViewResolver : IViewResolver
    {
        private List<Type> _forms;

        public List<Type> Forms
        {
            get
            {
                if (_forms == null)
                    SetForms();
                return _forms;
            }
        }

        public IEnumerable<Type> Views => GetForms();

        private void SetForms()
        {
            _forms = new List<Type>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                _forms.AddRange(
                    assembly.GetLoadableTypes()
                        .Where(
                            x =>
                                typeof(IView).GetTypeInfo()
                                    .IsAssignableFrom(x.GetTypeInfo()))
                        .ToList());
            }
        }

        private IEnumerable<Type> GetForms()
        {
            return this.Forms;
        }
    }
}