using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Game.Data.Configs
{
    [Serializable]
    public class WeaponConfig : IConfig
    {
        [field:SerializeField] public int Id { get; private set; }
        [field:SerializeField] public Mesh Mesh { get; private set; }
        [field:SerializeField] public Material Material { get; private set; }
        [field:SerializeField] public Sprite Icon { get; private set; }
        [field:SerializeField] public List<IncompatibilityItemConfig> Incompatibilities { get; private set; }
    }
}