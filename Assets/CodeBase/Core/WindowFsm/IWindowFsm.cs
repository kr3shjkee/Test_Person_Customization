using System;

namespace CodeBase.Core.WindowFsm
{
    public interface IWindowFsm
    {
        public event Action<Type> Opened;
        public event Action<Type> Closed;
        
        public IWindow CurrentWindow { get; }

        public void OpenWindow(Type window, bool inHistory);
        public void OpenWindow(Type window);
        
        public void CloseWindow(Type window);
        public void CloseWindow();
        
        public void ClearHistory();
    }
}