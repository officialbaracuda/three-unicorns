using System;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public static event Action OnAnyPickup;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Constants.PLAYER) {
            OnAnyPickup?.Invoke();
        }
    }
}
