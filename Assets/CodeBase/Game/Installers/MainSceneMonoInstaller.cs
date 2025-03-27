using CodeBase.Game.MVP.Models;
using CodeBase.Game.MVP.Presenters;
using CodeBase.Game.MVP.Services;
using CodeBase.Game.MVP.Views;
using CodeBase.Game.Ui_Elements;
using UnityEngine;
using Zenject;

namespace CodeBase.Game.Installers
{
    public class MainSceneMonoInstaller : MonoInstaller
    {
        [SerializeField] private MainUiView _mainUiView;
        [SerializeField] private LoadingView _loadingView;
        [SerializeField] private ItemsTypeButton _itemsTypeButtonPrefab;
        [SerializeField] private ItemButton _itemButtonPrefab;
        [SerializeField] private int _itemButtonsPoolCount;
        public override void InstallBindings()
        {
            BindFactories();
            BindPools();
            BindServices();
            BindViews();
            BindModels();
            BindPresenters();
        }

        private void BindFactories()
        {
            Container
                .BindFactory<ItemsTypeButton, ItemsTypeButton.Factory>()
                .FromComponentInNewPrefab(_itemsTypeButtonPrefab);
        }

        private void BindPools()
        {
            Container
                .BindMemoryPool<ItemButton, ItemButton.Pool>()
                .WithInitialSize(_itemButtonsPoolCount)
                .FromComponentInNewPrefab(_itemButtonPrefab)
                .UnderTransformGroup("Stone Elements Pool");
        }

        private void BindServices()
        {
            Container
                .BindInterfacesAndSelfTo<SaveLoadService>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<TimerService>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<UpdatePersonService>()
                .AsSingle();
        }

        private void BindViews()
        {
            Container
                .BindInstance(_mainUiView);
            
            Container
                .BindInstance(_loadingView);
        }

        private void BindModels()
        {
            Container
                .BindInterfacesAndSelfTo<MainUiModel>()
                .AsSingle();
        }
        
        private void BindPresenters()
        {
            Container
                .BindInterfacesAndSelfTo<MainUiPresenter>()
                .AsTransient();
            
            Container
                .BindInterfacesAndSelfTo<LoadingPresenter>()
                .AsTransient();
        }
    }
}