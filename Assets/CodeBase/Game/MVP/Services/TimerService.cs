using System;
using CodeBase.Game.Data.Enums;
using CodeBase.Game.Data.Settings;
using Cysharp.Threading.Tasks;

namespace CodeBase.Game.MVP.Services
{
    public class TimerService
    {
        private readonly float _duration;
        
        private bool _isTimerFinish = true;

        public TimerService(GameSettings gameSettings)
        {
            _duration = gameSettings.JsonSettings.LoadDuration;
        }
        public bool IsTimerFinish => _isTimerFinish;

        public async UniTask StartTimerAsync(Action<CallbackType> callback)
        {
            _isTimerFinish = false;

            await UniTask.Delay(TimeSpan.FromSeconds(_duration));

            _isTimerFinish = true;
            callback?.Invoke(CallbackType.Timer);
        }
    }
}