using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class PortalObserver : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private GameObject death;
    [SerializeField]
    private GameObject life;
    [SerializeField]
    private AudioClip clip;
    
    void Awake() => audioSource = GetComponent<AudioSource>();

    private void OnEnable() => CanEnterPortal.OnPortalEnter += Execute;
    private void OnDisable() => CanEnterPortal.OnPortalEnter -= Execute;

    private void Execute()
    {
        if (death.activeInHierarchy)
        {
            life.SetActive(true);
            death.SetActive(false);
            SpawnController.Instance.StopGhostSpawn();
        }
        else if(life.activeInHierarchy){
            life.SetActive(false);
            death.SetActive(true);
            SpawnController.Instance.StartGhostSpawn();
        }
        audioSource.clip = clip;
        audioSource.Play();
    }
}
