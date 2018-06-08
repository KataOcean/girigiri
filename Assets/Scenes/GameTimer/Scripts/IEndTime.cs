using UnityEngine.EventSystems;

namespace Girigiri
{
    interface IEndTime : IEventSystemHandler
    {
        void OnEndTime();
    }
}