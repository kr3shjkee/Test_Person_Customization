using System.Collections.Generic;
using CodeBase.Core.MVP.View;
using CodeBase.Game.Elements;
using UnityEngine;

namespace CodeBase.Game.MVP.Views
{
    public class PersonView : ViewBase
    {
        [field:SerializeField] public List<ChangeViewElement> ChangeElements { get; private set; }
    }
}