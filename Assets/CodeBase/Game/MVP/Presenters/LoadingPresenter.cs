using System;
using CodeBase.Core.MVP.Presenter;
using CodeBase.Core.WindowFsm;
using CodeBase.Game.Data.Enums;
using CodeBase.Game.MVP.Services;
using CodeBase.Game.MVP.Views;
using CodeBase.Game.Windows;
using Cysharp.Threading.Tasks;

namespace CodeBase.Game.MVP.Presenters
{
    public class LoadingPresenter : IPresenter
    {
        private readonly IWindowFsm _windowFsm;
        private readonly LoadingView _view;
        private readonly SaveLoadService _saveLoadService;
        private readonly TimerService _timerService;
        private readonly Type _window = typeof(Loading);
        
        private bool _isLoadingFinished;

        public LoadingPresenter(
            IWindowFsm windowFsm, 
            LoadingView view, 
            SaveLoadService saveLoadService, 
            TimerService timerService)
        {
            _windowFsm = windowFsm;
            _view = view;
            _saveLoadService = saveLoadService;
            _timerService = timerService;
        }
        
        public void Enable()
        {
            _windowFsm.Opened += OnHandleOpenWindow;
            _windowFsm.Closed += OnHandleCloseWindow;
        }

        public void Disable()
        {
            _windowFsm.Opened -= OnHandleOpenWindow;
            _windowFsm.Closed -= OnHandleCloseWindow;
        }

        private void OnHandleOpenWindow(Type window)
        {
            if(_window != window || _view == null) return;
            
            _view.Show();
            _view.Animation.PlayAnimation();
            _timerService.StartTimerAsync(OnHandleCallback).Forget();
            _saveLoadService.TryLoadDataAsync(OnHandleCallback).Forget();
        }
        
        private void OnHandleCloseWindow(Type window)
        {
            if(_window != window || _view == null) return;
            
            _view.Hide();
        }
        
        private void OnHandleCallback(CallbackType callbackType)
        {
            if (callbackType == CallbackType.Loading && _timerService.IsTimerFinish ||
                callbackType == CallbackType.Timer && _saveLoadService.IsLoadingFinish)
            {
                if(_isLoadingFinished)
                    return;
                
                _isLoadingFinished = true;
                _view.Animation.StopAnimation();
                _windowFsm.CloseWindow(typeof(Loading));
                _windowFsm.OpenWindow(typeof(MainUi), true);
            }
        }
    }
}