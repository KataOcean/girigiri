using UnityEngine.EventSystems;
namespace Girigiri
{
    interface ICreateChip : IEventSystemHandler
    {
        void OnCreateChip(Chip chip);
    }
}