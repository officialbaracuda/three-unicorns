using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject thirdPersonCamera;
    [SerializeField]
    private GameObject gameOverCamera;

    private void OnEnable() => PickupController.OnAnyPickup += Execute;
    private void OnDisable() => PickupController.OnAnyPickup -= Execute;

    private void Execute()
    {
        GameManager.Instance.GameOver();
        thirdPersonCamera.SetActive(false);
        gameOverCamera.SetActive(true);
    }
}
