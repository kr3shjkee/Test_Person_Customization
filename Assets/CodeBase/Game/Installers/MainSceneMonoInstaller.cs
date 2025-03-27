using UnityEngine;
using Zenject;

namespace CodeBase.Game.Installers
{
    public class MainSceneMonoInstaller : MonoInstaller
    {
        //[SerializeField] private MainUiView _mainUiView;
        public override void InstallBindings()
        {
            BindViews();
            BindPresenters();
        }

        private void BindPresenters()
        {
            //Container.BindInterfacesAndSelfTo<MainUiPresenter>().AsTransient();
        }

        private void BindViews()
        {
            //Container.BindInstance(_mainUiView);
        }
    }
}