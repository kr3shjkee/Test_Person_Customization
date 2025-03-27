using UnityEngine;

namespace CodeBase.Game.Data.Settings
{
    [CreateAssetMenu(fileName = "JsonSettings", menuName = "Settings/Settings/Create Json Settings", order = 0)]
    public class JsonSettings : ScriptableObject
    {
        [field: SerializeField] public string JsonName { get; private set; }
        [field: SerializeField] public float LoadDuration { get; private set; }
    }
}