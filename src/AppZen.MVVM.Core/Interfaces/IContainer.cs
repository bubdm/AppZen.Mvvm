using System;

namespace AppZen.Mvvm.Core.Interfaces
{
    public interface IContainer
    {
        Object Resolve(Type type);
        T Resolve<T>();
        void Release(object @object);
        //void Add(Tuple<Type,bool> types, Assembly assembly);
        //void Add(List<Tuple<Type, bool>> types, Assembly assembly);
    }
}