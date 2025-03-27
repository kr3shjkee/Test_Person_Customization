using UnityEngine;

namespace CodeBase.Game.Data.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/Create Game Settings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [field: SerializeField] public JsonSettings JsonSettings { get; private set; }
        [field: SerializeField] public CustomizationSettings CustomizationSettings { get; private set; }
    }
}