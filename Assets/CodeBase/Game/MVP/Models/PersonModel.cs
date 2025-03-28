using System.Collections.Generic;
using System.Linq;
using CodeBase.Game.Data.Configs;
using CodeBase.Game.Data.Enums;
using CodeBase.Game.Data.Settings;

namespace CodeBase.Game.MVP.Models
{
    public class PersonModel
    {
        private readonly GameSettings _gameSettings;
        
        private List<IListConfig> _listsConfigs;

        public PersonModel(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _listsConfigs = new List<IListConfig>();
            _listsConfigs.AddRange(_gameSettings.CustomizationSettings.BodyColors);
            _listsConfigs.AddRange(_gameSettings.CustomizationSettings.Items);
            _listsConfigs.AddRange(_gameSettings.CustomizationSettings.Weapons);
        }
        

        public IConfig GetConfigByTypeAndId(ItemType type, int id)
        {
            IConfig config = null;
            IListConfig listConfig = _listsConfigs.FirstOrDefault(list => list.Type == type);
            if (listConfig != null)
            {
                config = listConfig.Configs.FirstOrDefault(item => item.Id == id);
            }

            return config;
        }
    }
}