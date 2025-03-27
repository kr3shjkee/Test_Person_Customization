using CodeBase.Core.MVP.View;
using CodeBase.Game.Animations;
using UnityEngine;

namespace CodeBase.Game.MVP.Views
{
    public class LoadingView : CanvasGroupView
    {
        [field:SerializeField] public TextAnimation Animation { get; private set; }
    }
}