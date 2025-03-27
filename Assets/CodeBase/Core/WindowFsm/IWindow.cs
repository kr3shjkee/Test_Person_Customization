using System;

namespace CodeBase.Core.WindowFsm
{
    public interface IWindow
    {
        public event Action<Type> Opened;
        public event Action<Type> Closed;
        
        public void Open();
        public void Close();
    }
}