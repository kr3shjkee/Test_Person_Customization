using System;
using CodeBase.Game.Data.DTO;

namespace CodeBase.Game.MVP.Services
{
    public class UpdatePersonService
    {
        public event Action<UpdateViewDto> UpdateInvoked;
        public void UpdatePerson(UpdateViewDto dto)
        {
            UpdateInvoked?.Invoke(dto);
        }
    }
}