using CodeBase.Game.MVP.Presenters;
using CodeBase.Game.MVP.Services;
using CodeBase.Game.MVP.Views;
using UnityEngine;
using Zenject;

namespace CodeBase.Game.Installers
{
    public class MainSceneMonoInstaller : MonoInstaller
    {
        [SerializeField] private MainUiView _mainUiView;
        [SerializeField] private LoadingView _loadingView;
        public override void InstallBindings()
        {
            BindServices();
            BindViews();
            BindPresenters();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<SaveLoadService>().AsSingle();
            Container.BindInterfacesAndSelfTo<TimerService>().AsSingle();
        }

        private void BindViews()
        {
            Container.BindInstance(_mainUiView);
            Container.BindInstance(_loadingView);
        }
        
        private void BindPresenters()
        {
            Container.BindInterfacesAndSelfTo<MainUiPresenter>().AsTransient();
            Container.BindInterfacesAndSelfTo<LoadingPresenter>().AsTransient();
        }
    }
}