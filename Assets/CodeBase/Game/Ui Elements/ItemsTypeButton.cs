using System;
using CodeBase.Game.Data.Configs;
using CodeBase.Game.Data.Enums;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Game.Ui_Elements
{
    public class ItemsTypeButton : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<ItemsTypeButton> { }

        [SerializeField] private Button _button;
        [SerializeField] private Image _icon;

        private ItemType _type;

        public event Action<ItemType> ClickInvoked;

        public void Init(ItemType type, Sprite sprite)
        {
            _button.onClick.AddListener(InvokeClick);
            SetDefault();
            _type = type;
            _icon.sprite = sprite;
        }

        public void OnDestroy()
        {
            _button.onClick.RemoveListener(InvokeClick);
        }

        private void SetDefault()
        {
            transform.localScale = Vector3.one;
            gameObject.transform.localPosition = Vector3.zero;
        }

        private void InvokeClick()
        {
            ClickInvoked?.Invoke(_type);
        }
    }
}