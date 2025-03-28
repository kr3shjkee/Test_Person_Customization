using CodeBase.Game.Elements;
using CodeBase.Game.MVP.Models;
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
        [SerializeField] private PersonView _personView;
        [SerializeField] private ItemsTypeButton _itemsTypeButtonPrefab;
        [SerializeField] private ItemCard itemCardPrefab;
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
                .BindMemoryPool<ItemCard, ItemCard.Pool>()
                .WithInitialSize(_itemButtonsPoolCount)
                .FromComponentInNewPrefab(itemCardPrefab)
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
            
            Container
                .BindInstance(_personView);
        }

        private void BindModels()
        {
            Container
                .BindInterfacesAndSelfTo<MainUiModel>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<PersonModel>()
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
            
            Container
                .BindInterfacesAndSelfTo<PersonPresenter>()
                .AsTransient();
        }
    }
}