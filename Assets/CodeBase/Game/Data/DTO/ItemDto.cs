using System;
using CodeBase.Game.Data.Enums;

namespace CodeBase.Game.Data.DTO
{
    [Serializable]
    public class ItemDto
    {
        public ItemType Type;
        public int Id;

        public ItemDto(ItemType type, int id)
        {
            Type = type;
            Id = id;
        }
    }
}
