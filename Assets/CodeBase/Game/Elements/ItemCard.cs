using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Game.Elements
{
    public class ItemCard : MonoBehaviour
    {
        public class Pool : MonoMemoryPool<ItemCard> { }

        [SerializeField] private Button _acceptButton;
        [SerializeField] private Button _cancelButton;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _nameText;

        private int _id;

        public event Action<int> ClickInvoked;

        private void Awake()
        {
            _acceptButton.onClick.AddListener(AcceptClickHandler);
            _cancelButton.onClick.AddListener(CancelClickHandler);
        }

        private void OnDestroy()
        {
            _acceptButton.onClick.RemoveListener(AcceptClickHandler);
            _cancelButton.onClick.RemoveListener(CancelClickHandler);
        }

        public void Init(int id, Sprite sprite, string name)
        {
            _id = id;
            _icon.sprite = sprite;
            _nameText.text = name;
        }

        private void AcceptClickHandler()
        {
            ClickInvoked?.Invoke(_id);
        }
        
        private void CancelClickHandler()
        {
            ClickInvoked?.Invoke(0);
        }
    }
}