using System.Collections.Generic;
using CodeBase.Game.Data.Enums;
using UnityEngine;

namespace CodeBase.Game.Data.Configs
{
    public interface IListConfig
    {
        public ItemType Type { get; }
        public Sprite Icon { get; }
        public List<IConfig> Configs { get; }
    }
}