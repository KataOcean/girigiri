using UnityEngine.EventSystems;
namespace Girigiri
{
    interface IDropChip : IEventSystemHandler
    {
        void OnDropChip(Chip chip);
    }
}