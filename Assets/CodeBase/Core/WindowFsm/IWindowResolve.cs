namespace CodeBase.Core.WindowFsm
{
    public interface IWindowResolve
    {
        public void Set<TView>() 
            where TView : class, IWindow, new();

        public void Set<TWindow>(TWindow window) 
            where TWindow : class, IWindow;

        public void CleanUp();
    }
}