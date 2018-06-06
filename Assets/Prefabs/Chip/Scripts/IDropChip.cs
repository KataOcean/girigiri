using UnityEngine.EventSystems;
namespace Girigiri
{
    interface IDropChip : IEventSystemHandler
    {
        void OnDrop(Chip chip);
    }
}