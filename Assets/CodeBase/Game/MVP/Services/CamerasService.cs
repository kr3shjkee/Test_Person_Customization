using System;
using CodeBase.Game.Data.Enums;

namespace CodeBase.Game.MVP.Services
{
    public class CamerasService
    {
        public event Action<ItemType> ItemCameraActivateInvoked;
        public event Action ItemCameraDeactivateInvoked;

        public void InvokeActivateItemCamera(ItemType type)
        {
            ItemCameraActivateInvoked?.Invoke(type);
        }
        
        public void InvokeDeactivateItemCamera()
        {
            ItemCameraDeactivateInvoked?.Invoke();
        }
    }
}