using CodeBase.Core.Compositions;
using CodeBase.Core.MVP.Presenter;
using CodeBase.Core.MVP.View;
using CodeBase.Game.MVP.Presenters;
using CodeBase.Game.MVP.Views;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Game.Compositions
{
    public class CompositionsRoot : SceneCompositionRoot
    {
        [SerializeField] private SceneContext _sceneContext;
        
        private DiContainer _sceneContainer;
        
        public override UniTask Initialize(DiContainer diContainer)
        {
            _sceneContext.Run();
            _sceneContainer = _sceneContext.Container;

            ConstructView<MainUiView, MainUiPresenter>();
            ConstructView<LoadingView, LoadingPresenter>();

            return default;
        }
        
        private void ConstructView<TView, TPresenter>()
            where TView : ViewBase
            where TPresenter : class, IPresenter
        {
            _sceneContainer.Resolve<TView>().Construct(_sceneContainer.Resolve<TPresenter>());
        }
    }
}