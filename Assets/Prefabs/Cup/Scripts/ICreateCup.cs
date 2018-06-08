using UnityEngine.EventSystems;
namespace Girigiri
{
    interface ICreateCup : IEventSystemHandler
    {
        void OnCreateCup(Cup cup);
    }
}