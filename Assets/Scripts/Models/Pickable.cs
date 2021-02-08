using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Animator))]
public class Pickable : MonoBehaviour
{
    public Pool.Type type;
    public int value;
    public AudioClip clip;
}
