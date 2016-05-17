using System;

namespace AppZen.Mvvm.Windows.Extensions
{
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(object @object)
        {
            Object =(T)@object;
        }

        public T Object { get; set; }
    }
}