using UnityEngine.EventSystems;
namespace Girigiri
{
    interface IBrokenCup : IEventSystemHandler
    {
        void OnBrokenCup(Cup cup);
    }
}