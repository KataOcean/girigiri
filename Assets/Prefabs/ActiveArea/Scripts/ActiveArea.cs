using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Girigiri
{
    public class ActiveArea : MonoBehaviour
    {
        void OnTriggerExit2D(Collider2D collider)
        {
            var chip = collider.gameObject.GetComponent<Chip>();
            if (chip != null)
            {
                chip.Broken();
            }
        }

    }
}