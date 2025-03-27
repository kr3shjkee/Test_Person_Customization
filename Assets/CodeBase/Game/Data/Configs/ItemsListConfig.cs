using System;
using System.Collections.Generic;
using CodeBase.Game.Data.Enums;
using UnityEngine;

namespace CodeBase.Game.Data.Configs
{
    [Serializable]
    public class ItemsListConfig
    {
        [field:SerializeField] public ItemType Type { get; private set; }
        [field:SerializeField] public List<ItemConfig> Items { get; private set; }
    }
}