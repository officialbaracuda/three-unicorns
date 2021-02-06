using UnityEngine;

[CreateAssetMenu(fileName = "New Pickable", menuName = "Pickable")]
public class Pickable : ScriptableObject
{
    public string value;
    public AudioClip clip;
}
