using System;
using System.Collections.Generic;
using CodeBase.Game.Data.Enums;
using UnityEngine;

namespace CodeBase.Game.Data.Configs
{
    [Serializable]
    public class ItemsListConfig : IListConfig
    {
        [field:SerializeField] public ItemType Type { get; private set; }
        [field:SerializeField] public Sprite Icon { get; private set; }
        
        [SerializeField] private List<ItemConfig> _items;

        public List<IConfig> Configs => new List<IConfig>(_items);
    }
}