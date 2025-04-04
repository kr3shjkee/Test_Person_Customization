﻿using System;
using System.Collections.Generic;
using CodeBase.Core.MVP.Presenter;
using CodeBase.Core.WindowFsm;
using CodeBase.Game.Data.Configs;
using CodeBase.Game.Data.DTO;
using CodeBase.Game.Data.Enums;
using CodeBase.Game.Elements;
using CodeBase.Game.MVP.Models;
using CodeBase.Game.MVP.Services;
using CodeBase.Game.MVP.Views;
using CodeBase.Game.Windows;
using UnityEngine;

namespace CodeBase.Game.MVP.Presenters
{
    public class MainUiPresenter : IPresenter
    {
        private readonly IWindowFsm _windowFsm;
        private readonly MainUiView _view;
        private readonly MainUiModel _model;
        private readonly UpdatePersonService _updatePersonService;
        private readonly CamerasService _camerasService;
        
        private readonly ItemsTypeButton.Factory _factory;
        private readonly ItemCard.Pool _pool;
        
        private readonly Type _window = typeof(MainUi);

        private List<ItemsTypeButton> _itemTypesButtons;
        private List<ItemCard> _items;

        public MainUiPresenter(
            IWindowFsm windowFsm, 
            MainUiView view, 
            MainUiModel model,
            UpdatePersonService updatePersonService,
            CamerasService camerasService,
            ItemsTypeButton.Factory factory,
            ItemCard.Pool pool)
        {
            _windowFsm = windowFsm;
            _view = view;
            _model = model;
            _updatePersonService = updatePersonService;
            _camerasService = camerasService;
            _factory = factory;
            _pool = pool;
        }
        
        public void Enable()
        {
            _windowFsm.Opened += OnHandleOpenWindow;
            _windowFsm.Closed += OnHandleCloseWindow;
            
            _view.BackButton.onClick.AddListener(BackButtonHandler);
            _view.ZoomInButton.onClick.AddListener(ZoomInButtonHandler);
            _view.ZoomOutButton.onClick.AddListener(ZoomOutButtonHandler);

            CreateItemTypesButtons();
        }

        public void Disable()
        {
            _windowFsm.Opened -= OnHandleOpenWindow;
            _windowFsm.Closed -= OnHandleCloseWindow;
            
            _view.BackButton.onClick.RemoveListener(BackButtonHandler);
            _view.ZoomInButton.onClick.RemoveListener(ZoomInButtonHandler);
            _view.ZoomOutButton.onClick.RemoveListener(ZoomOutButtonHandler);

            UnsubscribeButtons();
        }

        private void OnHandleOpenWindow(Type window)
        {
            if(_window != window || _view == null) return;
            
            _view.Show();
        }
        
        private void OnHandleCloseWindow(Type window)
        {
            if(_window != window || _view == null) return;
            
            _view.Hide();
        }

        private void UnsubscribeButtons()
        {
            foreach (ItemsTypeButton button in _itemTypesButtons)
            {
                button.ClickInvoked -= ItemTypeButtonHandler;
            }
        }
        
        private void CreateItemTypesButtons()
        {
            _itemTypesButtons = new List<ItemsTypeButton>();

            foreach (IListConfig listConfig in _model.ListsConfigs)
            {
                CreateButton(listConfig.Type, listConfig.Icon);
            }
        }

        private void CreateButton(ItemType type, Sprite sprite)
        {
            ItemsTypeButton button = _factory.Create();
            button.gameObject.transform.SetParent(_view.ItemTypesParent, false);
            button.Init(type, sprite);
            button.ClickInvoked += ItemTypeButtonHandler;
            _itemTypesButtons.Add(button);
        }

        private void ItemTypeButtonHandler(ItemType type)
        {
            List<IConfig> items = _model.GetItemsByType(type);
            
            if(items.Count == 0)
                return;
            
            _items = new List<ItemCard>();
            foreach (IConfig config in items)
            {
                if(config.Id == 0)
                    continue;
                
                ItemCard card = _pool.Spawn();
                card.gameObject.transform.SetParent(_view.ItemsParent);
                card.Init(config.Id, config.Icon, config.Name);
                card.ClickInvoked += ItemButtonHandler;
                card.PointerEnterInvoked += PointerEnterHandler;
                card.PointerExitInvoked += PointerExitHandler;
                _items.Add(card);
            }
            _view.ControllersAndItemsObject.SetActive(true);
        }

        private void BackButtonHandler()
        {
            _view.ControllersAndItemsObject.SetActive(false);
            if (_items.Count > 0)
            {
                foreach (ItemCard item in _items)
                {
                    item.ClickInvoked -= ItemButtonHandler;
                    item.PointerEnterInvoked -= PointerEnterHandler;
                    item.PointerExitInvoked -= PointerExitHandler;
                    _pool.Despawn(item);
                }
            }
            _items.Clear();
            _camerasService.InvokeDeactivateItemCamera();
        }

        private void ItemButtonHandler(int id)
        {
            IConfig config = _model.GetItemConfigById(id);
            if (config != null)
            {
                UpdateViewDto dto = new UpdateViewDto
                {
                    Config = config,
                    Type = _model.GetCurrentType(),
                    IsCheckIncompatibility = true,
                    IsSave = true
                };
                _updatePersonService.UpdatePerson(dto);
            }
        }

        private void ZoomOutButtonHandler()
        {
            _camerasService.InvokeDeactivateItemCamera();
        }
        
        private void ZoomInButtonHandler()
        {
            ItemType type = _model.GetCurrentType();
            _camerasService.InvokeActivateItemCamera(type);
        }

        private void PointerEnterHandler(int id)
        {
            IConfig config = _model.GetItemConfigById(id);
            if (config != null)
            {
                UpdateViewDto dto = new UpdateViewDto
                {
                    Config = config,
                    Type = _model.GetCurrentType(),
                    IsCheckIncompatibility = true,
                    IsSave = false
                };
                _updatePersonService.UpdatePerson(dto);
            }
        }

        private void PointerExitHandler()
        {
            _updatePersonService.InvokeReturnItem();
        }
    }
}