using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Game.Ui_Elements
{
    public class ItemButton : MonoBehaviour
    {
        public class Pool : MonoMemoryPool<ItemButton> { }

        [SerializeField] private Button _button;
        [SerializeField] private Image _icon;

        private int _id;

        public event Action<int> ClickInvoked;

        private void Awake()
        {
            _button.onClick.AddListener(ClickHandler);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ClickHandler);
        }

        public void Init(int id, Sprite sprite)
        {
            _id = id;
            _icon.sprite = sprite;
        }

        private void ClickHandler()
        {
            ClickInvoked?.Invoke(_id);
        }
    }
}