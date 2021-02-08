using UnityEngine;

public class ChaserObserver : MonoBehaviour
{
    [SerializeField]
    private GameObject thirdPersonCamera;
    [SerializeField]
    private GameObject gameOverCamera;

    private void OnEnable() => CanChase.OnCatch += Execute;
    private void OnDisable() => CanChase.OnCatch -= Execute;

    private void Execute()
    {
        GameManager.Instance.GameOver();
        thirdPersonCamera.SetActive(false);
        gameOverCamera.SetActive(true);
    }
}
