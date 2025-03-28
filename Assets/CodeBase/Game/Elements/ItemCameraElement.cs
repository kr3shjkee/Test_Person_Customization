using System.Collections.Generic;
using Cinemachine;
using CodeBase.Game.Data.Enums;
using UnityEngine;

namespace CodeBase.Game.Elements
{
    public class ItemCameraElement : MonoBehaviour
    {
        [SerializeField] private List<ItemType> _types;
        [SerializeField] private CinemachineVirtualCamera _camera;

        public List<ItemType> Types => _types;
        public CinemachineVirtualCamera Camera => _camera;
    }
}