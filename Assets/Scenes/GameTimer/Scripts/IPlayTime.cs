using UnityEngine.EventSystems;

namespace Girigiri
{
    interface IPlayTime : IEventSystemHandler
    {
        void OnPlayTime();
    }
}