using CodeBase.Game.Data.Configs;
using CodeBase.Game.Data.Enums;

namespace CodeBase.Game.Data.DTO
{
    public class UpdateViewDto
    {
        public IConfig Config;
        public ItemType Type;
        public bool IsCheckIncompatibility;
    }
}