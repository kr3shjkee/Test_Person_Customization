using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Game.Data.Configs
{
    public interface IConfig
    {
        public int Id { get; }
        public Sprite Icon { get; }
        public List<IncompatibilityItemConfig> Incompatibilities { get; }
    }
}