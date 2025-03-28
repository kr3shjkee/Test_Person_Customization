using System;
using CodeBase.Game.Data.DTO;

namespace CodeBase.Game.MVP.Services
{
    public class UpdatePersonService
    {
        public event Action<UpdateViewDto> UpdateInvoked;
        public event Action ReturnItemInvoked;
        public void UpdatePerson(UpdateViewDto dto)
        {
            UpdateInvoked?.Invoke(dto);
        }

        public void InvokeReturnItem()
        {
            ReturnItemInvoked?.Invoke();
        }
    }
}