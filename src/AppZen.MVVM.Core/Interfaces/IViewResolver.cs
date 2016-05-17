using System;
using System.Collections.Generic;

namespace AppZen.Mvvm.Core.Interfaces
{
    public interface IViewResolver
    {
        IEnumerable<Type> Views { get; }
    }
}