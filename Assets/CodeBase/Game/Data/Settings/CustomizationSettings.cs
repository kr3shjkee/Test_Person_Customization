using System.Collections.Generic;
using CodeBase.Game.Data.Configs;
using UnityEngine;

namespace CodeBase.Game.Data.Settings
{
    [CreateAssetMenu(fileName = "CustomizationSettings", menuName = "Settings/Settings/Create Customization Settings", order = 0)]
    public class CustomizationSettings : ScriptableObject
    {
        [field:SerializeField] public List<ItemsListConfig> Items { get; private set; }
        [field:SerializeField] public List<BodyColorConfig> BodyColors { get; private set; }
        [field:SerializeField] public List<WeaponsListConfig> Weapons { get; private set; }
    }
}