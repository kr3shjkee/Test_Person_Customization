using System;
using System.Collections.Generic;
using CodeBase.Game.Data.Enums;
using UnityEngine;

namespace CodeBase.Game.Data.Configs
{
    [Serializable]
    public class WeaponsListConfig
    {
        [field:SerializeField] public ItemType Type { get; private set; }
        [field:SerializeField] public List<WeaponConfig> Weapons { get; private set; }
    }
}