using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Game.Data.Configs
{
    [Serializable]
    public class BodyColorConfig : IConfig
    {
        [field:SerializeField] public int Id { get; private set; }
        [field:SerializeField] public Sprite Icon { get; private set; }
        [field:SerializeField] public string Name { get; private set; }
        [field:SerializeField] public Material Material { get; private set; }
        [field:SerializeField] public List<IncompatibilityItemConfig> Incompatibilities { get; private set; }
    }
}