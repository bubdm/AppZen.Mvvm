using System;
using System.Reflection;

namespace AppZen.Mvvm.Core.Extensions
{
    public static class TypeSwitch
    {
        public static Switch<TSource> On<TSource>(TSource value)
        {
            return new Switch<TSource>(value);
        }

        public class Switch<TSource>
        {
            private TSource value;
            private bool _handled;

            internal Switch(TSource value)
            {
                this.value = value;
            }

            public Switch<TSource> Case<TTarget>(Action<TTarget> action)
                where TTarget : TSource
            {
                if (!_handled)
                {
                    var sourceType = value.GetType();
                    var targetType = typeof(TTarget);
                    if (targetType.GetTypeInfo().IsAssignableFrom(sourceType.GetTypeInfo()))
                    {
                        action?.Invoke((TTarget)value);
                        _handled = true;
                    }
                }

                return this;
            }

            public void Default(Action<TSource> action)
            {
                if (!_handled)
                    action?.Invoke(value);
            }
        }
    }
}
