using System.Collections.Generic;
using Cinemachine;
using CodeBase.Core.MVP.View;
using CodeBase.Game.Elements;
using UnityEngine;

namespace CodeBase.Game.MVP.Views
{
    public class CamerasView : ViewBase
    {
        [field:SerializeField] public CinemachineVirtualCamera RotateCamera { get; private set; }
        [field:SerializeField] public List<ItemCameraElement> ItemCameras { get; private set; }
        [field:SerializeField] public CinemachineBrain Brain { get; private set; }
    }
}