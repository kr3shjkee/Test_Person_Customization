using System;

namespace CodeBase.Core.WindowFsm
{
    public class Window : IWindow
    {
        public event Action<Type> Opened;
        public event Action<Type> Closed;

        public Window() { }

        public void Open() => Opened?.Invoke(GetType());
        public void Close() => Closed?.Invoke(GetType());
    }
}