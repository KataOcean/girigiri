using UnityEngine.EventSystems;
namespace Girigiri
{
    interface ICreateChip : IEventSystemHandler
    {
        void OnCreate(Chip chip);
    }
}