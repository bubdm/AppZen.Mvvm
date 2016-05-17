namespace AppZen.Mvvm.Windows.Extensions
{
    public class EventArgsHandled<T> : EventArgs<T>
    {
        public bool Handled { get; set; }
        public EventArgsHandled(T @object) : base(@object)
        {
        }
    }
}