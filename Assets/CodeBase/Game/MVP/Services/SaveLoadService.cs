using System;
using System.Collections.Generic;
using System.IO;
using CodeBase.Game.Data.DTO;
using CodeBase.Game.Data.Enums;
using CodeBase.Game.Data.Settings;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Game.MVP.Services
{
    public class SaveLoadService
    {
        private readonly string _fileName;
        private readonly GameSettings _gameSettings;

        private string _filePath;
        private SaveDto _dto;
        private bool _isLoadingFinish = true;

        public SaveLoadService(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _fileName = _gameSettings.JsonSettings.JsonName;
            _filePath = Application.persistentDataPath + "/" + _fileName;
        }

        public bool IsLoadingFinish => _isLoadingFinish;
        public SaveDto Dto => _dto;

        public async UniTask TryLoadDataAsync(Action<CallbackType> callback)
        {
            _isLoadingFinish = false;

            if (!File.Exists(_filePath))
            {
                CreateNewDto();
                callback?.Invoke(CallbackType.Loading);
                _isLoadingFinish = true;
                return;
            }

            _dto = JsonUtility.FromJson<SaveDto>(await File.ReadAllTextAsync(_filePath));

            if (_dto == null)
            {
                CreateNewDto();
            }

            callback?.Invoke(CallbackType.Loading);
            _isLoadingFinish = true;
        }

        private void CreateNewDto()
        {
            
            _dto = new SaveDto();
            _dto.Items = new List<ItemDto>();

            foreach (ItemType fruit in Enum.GetValues(typeof(ItemType)))
            {
                if (fruit != ItemType.Invalid)
                {
                    ItemDto item = new ItemDto(fruit, 0);
                    _dto.Items.Add(item);
                }
            }
            _dto.BodyColorType = BodyColorType.White;

            SaveData();
        }

        private void SaveData()
        {
            File.WriteAllText(_filePath, JsonUtility.ToJson(_dto)); ;
        }
    }
}