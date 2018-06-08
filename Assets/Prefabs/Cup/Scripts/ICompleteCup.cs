using UnityEngine.EventSystems;
namespace Girigiri
{
    interface ICompleteCup : IEventSystemHandler
    {
        void OnCompleteCup(Cup cup);
    }
}