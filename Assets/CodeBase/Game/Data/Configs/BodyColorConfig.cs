using System;
using CodeBase.Game.Data.Enums;
using UnityEngine;

namespace CodeBase.Game.Data.Configs
{
    [Serializable]
    public class BodyColorConfig
    {
        [field:SerializeField] public BodyColorType Type { get; private set; }
        [field:SerializeField] public Material Material { get; private set; }
    }
}