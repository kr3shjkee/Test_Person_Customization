using System.Linq;
using CodeBase.Core.MVP.Presenter;
using CodeBase.Game.Data.Configs;
using CodeBase.Game.Data.DTO;
using CodeBase.Game.Elements;
using CodeBase.Game.MVP.Models;
using CodeBase.Game.MVP.Services;
using CodeBase.Game.MVP.Views;

namespace CodeBase.Game.MVP.Presenters
{
    public class PersonPresenter : IPresenter
    {
        private readonly UpdatePersonService _updatePersonService;
        private readonly SaveLoadService _saveLoadService;
        private readonly PersonView _view;
        private readonly PersonModel _model;

        public PersonPresenter(
            UpdatePersonService updatePersonService, 
            SaveLoadService saveLoadService, 
            PersonView view, 
            PersonModel model)
        {
            _updatePersonService = updatePersonService;
            _saveLoadService = saveLoadService;
            _view = view;
            _model = model;
            
            _updatePersonService.UpdateInvoked += UpdateElementByDto;
            _saveLoadService.DtoReadyInvoked += UpdateElementsAfterLoad;
        }
        public void Enable()
        {
            
        }

        public void Disable()
        {
            _updatePersonService.UpdateInvoked -= UpdateElementByDto;
            _saveLoadService.DtoReadyInvoked -= UpdateElementsAfterLoad;
        }

        private void UpdateElementsAfterLoad()
        {
            foreach (ItemDto element in _saveLoadService.Dto.Items)
            {
                IConfig config = _model.GetConfigByTypeAndId(element.Type, element.Id);
                if (config != null)
                {
                    ChangeViewElement changeElement = _view.ChangeElements.FirstOrDefault(item => item.Type == element.Type);
                    if(changeElement!=null)
                        changeElement.UpdateView(config);
                }
            }
        }

        private void UpdateElementByDto(UpdateViewDto dto)
        {
            ChangeViewElement element = _view.ChangeElements.FirstOrDefault(item => item.Type == dto.Type);
            if(element==null)
                return;
            
            if (dto.IsCheckIncompatibility)
            {
                foreach (IncompatibilityItemConfig incompatibilityItem in dto.Config.Incompatibilities)
                {
                    ChangeViewElement checkedItem = _view.ChangeElements.FirstOrDefault(item => item.Type == incompatibilityItem.Type);
                    if(checkedItem != null && checkedItem.Id == incompatibilityItem.Id)
                        return;
                }
            }
            element.UpdateView(dto.Config);
            _saveLoadService.SaveItem(dto.Type, dto.Config.Id);
        }
    }
}