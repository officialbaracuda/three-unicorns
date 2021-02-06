using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SphereCollider))]
public class Pickup : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    public Pickable pickable;
    private void Awake() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() => PickupController.OnAnyPickup += Execute;
    private void OnDisable() => PickupController.OnAnyPickup -= Execute;

    private void Execute() {
        GameManager.Instance.Pickup(pickable);
        animator.SetBool(Constants.IS_PICKEDUP, true);

        audioSource.clip = pickable.clip;
        audioSource.Play();
    }
}
