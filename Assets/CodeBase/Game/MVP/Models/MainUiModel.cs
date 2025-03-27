using System.Collections.Generic;
using System.Linq;
using CodeBase.Game.Data.Configs;
using CodeBase.Game.Data.Enums;
using CodeBase.Game.Data.Settings;

namespace CodeBase.Game.MVP.Models
{
    public class MainUiModel
    {
        private readonly GameSettings _gameSettings;

        private List<IListConfig> _listsConfigs;
        private List<IConfig> _currentItems;
        
        public MainUiModel(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _listsConfigs = new List<IListConfig>();
            _listsConfigs.AddRange(_gameSettings.CustomizationSettings.BodyColors);
            _listsConfigs.AddRange(_gameSettings.CustomizationSettings.Items);
            _listsConfigs.AddRange(_gameSettings.CustomizationSettings.Weapons);
        }

        public List<IListConfig> ListsConfigs => _listsConfigs;

        public List<IConfig> GetItemsByType(ItemType type)
        {
            _currentItems = new List<IConfig>();
            IListConfig config = _listsConfigs.FirstOrDefault(item => item.Type == type);

            if (config != null)
            {
                _currentItems = new List<IConfig>(config.Configs);
            }

            return _currentItems;
        }

        public IConfig GetItemConfigById(int id)
        {
            return _currentItems.FirstOrDefault(item => item.Id == id);
        }
    }
}