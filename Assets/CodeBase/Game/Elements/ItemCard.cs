using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Game.Elements
{
    public class ItemCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public class Pool : MonoMemoryPool<ItemCard> { }

        [SerializeField] private Button _acceptButton;
        [SerializeField] private Button _cancelButton;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _nameText;

        private int _id;

        public event Action<int> ClickInvoked;
        public event Action<int> PointerEnterInvoked;
        public event Action PointerExitInvoked;

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
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerEnterInvoked?.Invoke(_id);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PointerExitInvoked?.Invoke();
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