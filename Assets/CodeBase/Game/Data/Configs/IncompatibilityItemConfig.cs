using System;
using CodeBase.Game.Data.Enums;
using UnityEngine;

namespace CodeBase.Game.Data.Configs
{
    [Serializable]
    public class IncompatibilityItemConfig
    {
        [field:SerializeField] public ItemType Type { get; private set; }
        [field:SerializeField] public int Id { get; private set; }
    }
}