using CodeBase.Core.MVP.Presenter;

namespace CodeBase.Core.MVP.View
{
    public interface IView
    {
        public void Construct(IPresenter presenter);
    }
}