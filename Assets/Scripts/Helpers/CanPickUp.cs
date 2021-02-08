using System;
using UnityEngine;

public class CanPickUp : MonoBehaviour
{
    public static event Action<GameObject> OnAnyPickup;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Constants.PICKABLE) {
            OnAnyPickup?.Invoke(other.gameObject);
        }
    }
}
