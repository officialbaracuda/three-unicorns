using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PickupObserver : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    private Pickable pickable;
    void Awake() => audioSource = GetComponent<AudioSource>();
    
    private void OnEnable() => CanPickUp.OnAnyPickup += Execute;
    private void OnDisable() => CanPickUp.OnAnyPickup -= Execute;

    private void Execute(GameObject gameObject) {
        pickable = gameObject.GetComponent<Pickable>();
        animator = gameObject.GetComponent<Animator>();

        GameManager.Instance.Pickup(pickable);
        animator.SetBool(Constants.IS_PICKEDUP, true);

        audioSource.clip = pickable.clip;
        audioSource.Play();

        SpawnController.Instance.Remove(gameObject, pickable.type);
    }
}
