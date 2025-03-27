using CodeBase.Core.MVP.View;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Game.MVP.Views
{
    public class MainUiView : CanvasGroupView
    {
        [field:SerializeField] public Button BackButton { get; private set; }
        [field:SerializeField] public Button ZoomInButton { get; private set; }
        [field:SerializeField] public Button ZoomOutButton { get; private set; }
        [field:SerializeField] public Transform ItemsParent { get; private set; }
        [field:SerializeField] public Transform ItemTypesParent { get; private set; }
        [field:SerializeField] public GameObject ControllersAndItemsObject { get; private set; }
    }
}