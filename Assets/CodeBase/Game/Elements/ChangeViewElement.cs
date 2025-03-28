using CodeBase.Game.Data.Configs;
using CodeBase.Game.Data.Enums;
using UnityEngine;

namespace CodeBase.Game.Elements
{
    public class ChangeViewElement : MonoBehaviour
    {
        [SerializeField] private ItemType _type;
        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] private MeshFilter _meshFilter;
        [SerializeField] private MeshRenderer _meshRenderer;

        private int _id;
        
        public ItemType Type => _type;
        public int Id => _id;

        public void UpdateView(IConfig config)
        {
            if (config is BodyColorConfig bodyColorConfig)
            {
                _skinnedMeshRenderer.material = bodyColorConfig.Material;
            }
            else if (config is ItemConfig itemConfig)
            {
                _skinnedMeshRenderer.sharedMesh = itemConfig.Mesh;
            }
            else if (config is WeaponConfig weaponConfig)
            {
                _meshFilter.mesh = weaponConfig.Mesh;
                _meshRenderer.material = weaponConfig.Material;
            }
            else
            {
                Debug.Log("Wrong config type");
                return;
            }

            _id = config.Id;
        }
    }
}