using System;
using UnityEngine;

public class CanEnterPortal : MonoBehaviour
{
    public static event Action OnPortalEnter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Constants.PORTAL)
        {
            OnPortalEnter?.Invoke();
        }
    }
}
